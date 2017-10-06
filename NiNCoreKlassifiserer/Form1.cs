using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using RødlisteKlassifiserer;

namespace NiNCoreKlassifiserer
{
    public partial class Form1 : Form
    {
        private static readonly Dictionary<RødlisteKlassifisering, List<Naturområde>> RødlistedeNaturområderDict =
            new Dictionary<RødlisteKlassifisering, List<Naturområde>>();

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

                List<NaturområdeType> naturområdeTyper = null;

                if (rødlisteKlassifisering.NaturområdeTypeKode != null)
                {
                    naturområdeTypeKodeVerdi = rødlisteKlassifisering.NaturområdeTypeKode.nivå + "_" +
                                               rødlisteKlassifisering.NaturområdeTypeKode.verdi;
                    naturområdeTyper = GetNaturområdeTyper(naturområdeTypeKodeVerdi).ToList();
                }
                else
                {
                    foreach (var kartleggingsKode in rødlisteKlassifisering.KartleggingsKode)
                    {
                        naturområdeTypeKodeVerdi = kartleggingsKode.NaturområdeTypeKode.nivå + "_" +
                                                   kartleggingsKode.NaturområdeTypeKode.verdi + "-" +
                                                   kartleggingsKode.verdi;
                        naturområdeTyper = GetNaturområdeTyper(naturområdeTypeKodeVerdi).ToList();
                    }
                }

                if (naturområdeTyper == null) continue;

                CheckNaturområdeTypeForBeskrivelsesvariabel(rødlisteKlassifisering, naturområdeTyper);
            }
        }

        private static void CheckNaturområdeTypeForBeskrivelsesvariabel(RødlisteKlassifisering rødlisteKlassifisering,
            List<NaturområdeType> naturområdeTyper)
        {
            foreach (var naturområdeType in naturområdeTyper)
            {
                if (rødlisteKlassifisering.Beskrivelsesvariabel.Count <= 0)
                {
                    AddNaturområdeToDictionary(rødlisteKlassifisering, naturområdeType.Naturområde);
                    continue;
                }
                if (rødlisteKlassifisering.Beskrivelsesvariabel.Count == 1 &&
                    naturområdeType.Beskrivelsesvariabel.Any(d =>
                        d.kode == rødlisteKlassifisering.Beskrivelsesvariabel.First().verdi))
                {
                    AddNaturområdeToDictionary(rødlisteKlassifisering, naturområdeType.Naturområde);
                    continue;
                }
                var allBeskrivelsesvariablerPresent = true;
                foreach (var beskrivelsesvariabel in rødlisteKlassifisering.Beskrivelsesvariabel)
                {
                    if (naturområdeType.Beskrivelsesvariabel.Any(d => d.kode == beskrivelsesvariabel.verdi))
                        continue;
                    allBeskrivelsesvariablerPresent = false;
                    break;
                }
                if (allBeskrivelsesvariablerPresent)
                    AddNaturområdeToDictionary(rødlisteKlassifisering, naturområdeType.Naturområde);
            }
        }

        private static void AddNaturområdeToDictionary(RødlisteKlassifisering rødlisteKlassifisering,
            Naturområde naturområde)
        {
            if (!RødlistedeNaturområderDict.ContainsKey(rødlisteKlassifisering))
                RødlistedeNaturområderDict[rødlisteKlassifisering] = new List<Naturområde>();
            RødlistedeNaturområderDict[rødlisteKlassifisering].Add(naturområde);
        }

        private static IEnumerable<NaturområdeType> GetNaturområdeTyper(string naturområdeTypeKodeVerdi)
        {
            return DataConnection.Context.NaturområdeType.Where(d =>
                d.kode == naturområdeTypeKodeVerdi);
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