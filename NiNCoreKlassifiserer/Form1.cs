using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Forms_dev3;

namespace NiNCoreKlassifiserer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassifyRødlistedeOmråder();
        }

        private static void ClassifyRødlistedeOmråder()
        {
            foreach (var rødlisteKlassifisering in RødlisteKlassifiserer.DataConnection.Context
                .RødlisteKlassifiseringSet)
            {
                string naturområdeTypeKodeVerdi;

                var naturområder = new List<Naturområde>();

                if (rødlisteKlassifisering.NaturområdeTypeKode != null)
                {
                    naturområdeTypeKodeVerdi = rødlisteKlassifisering.NaturområdeTypeKode.nivå + "_" +
                                               rødlisteKlassifisering.NaturområdeTypeKode.verdi;
                    naturområder = GetNaturområderLike(naturområdeTypeKodeVerdi).ToList();
                    naturområder.AddRange(GetNaturområder(naturområdeTypeKodeVerdi));
                }
                else
                {
                    foreach (var kartleggingsKode in rødlisteKlassifisering.KartleggingsKode)
                    {
                        naturområdeTypeKodeVerdi = kartleggingsKode.NaturområdeTypeKode.nivå + "_" +
                                                   kartleggingsKode.NaturområdeTypeKode.verdi + "-" +
                                                   kartleggingsKode.verdi;
                        naturområder.AddRange(GetNaturområder(naturområdeTypeKodeVerdi).ToList());
                        if (kartleggingsKode.KartleggingsKodeAggregate == null) continue;
                        naturområdeTypeKodeVerdi =
                            kartleggingsKode.KartleggingsKodeAggregate.NaturområdeTypeKode.nivå + "_" +
                            kartleggingsKode.KartleggingsKodeAggregate.NaturområdeTypeKode.verdi + "-" +
                            kartleggingsKode.KartleggingsKodeAggregate.nivå + "-" +
                            kartleggingsKode.KartleggingsKodeAggregate.verdi;
                        naturområder.AddRange(GetNaturområder(naturområdeTypeKodeVerdi).ToList());
                    }
                }

                if (naturområder.Count == 0) continue;

                CheckNaturområdeTypeForBeskrivelsesvariabel(rødlisteKlassifisering, naturområder);


            }
            RødlisteKlassifiserer.DataConnection.Context.SaveChanges();
        }

        private static IEnumerable<Naturområde_RødlisteKlassifisering> SaveRødlistedeNaturområder(RødlisteKlassifisering rødlisteKlassifisering,
            IEnumerable<Naturområde> naturområder)
        {
            return naturområder.Select(naturområde => new Naturområde_RødlisteKlassifisering
            {
                naturområde_id = naturområde.id,
                RødlisteKlassifisering = rødlisteKlassifisering
            });
        }

        private static void CheckNaturområdeTypeForBeskrivelsesvariabel(RødlisteKlassifisering rødlisteKlassifisering,
            IEnumerable<Naturområde> naturområder)
        {
            if (rødlisteKlassifisering.Beskrivelsesvariabel.Count > 0)
            {
                naturområder = rødlisteKlassifisering.Beskrivelsesvariabel.Aggregate(naturområder,
                    (current, beskrivelsesvariabel) => current.Where(d =>
                        d.Beskrivelsesvariabel.Any(e => e.kode == beskrivelsesvariabel.verdi)));
            }
            RødlisteKlassifiserer.DataConnection.Context.Naturområde_RødlisteKlassifiseringSet.AddRange(
                SaveRødlistedeNaturområder(rødlisteKlassifisering, naturområder));
        }

        private static IEnumerable<Naturområde> GetNaturområder(string naturområdeTypeKodeVerdi)
        {
            return DataConnection.Context.Naturområde.Where(d =>
                d.NaturområdeType.Any(e => e.kode == naturområdeTypeKodeVerdi));
        }


        private static IEnumerable<Naturområde> GetNaturområderLike(string naturområdeTypeKodeVerdi)
        {
            return DataConnection.Context.Naturområde.Where(d =>
                d.NaturområdeType.Any(e => e.kode.StartsWith(naturområdeTypeKodeVerdi + "-")));
        }
    }

    internal static class DataConnection
    {
        public static readonly NiNCore_norskEntities Context =
            new NiNCore_norskEntities();

        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null)
            where T : class, new()
        {
            if (!dbSet.Any()) return dbSet.Add(entity);

            var existingRows = dbSet.Where(predicate ?? throw new ArgumentNullException(nameof(predicate)));
            if (!existingRows.Any()) return dbSet.Add(entity);

            Context.Entry(existingRows.First()).State = EntityState.Unchanged;
            return existingRows.First();
        }
    }
}