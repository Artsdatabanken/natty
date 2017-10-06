using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RødlisteKlassifiserer;

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
            
            var rødlistedeNaturområderDict = new Dictionary<RødlisteKlassifisering, List<Naturområde>>();

            foreach (var rødlisteKlassifisering in RødlisteKlassifiserer.DataConnection.Context
                .RødlisteKlassifiseringSet)
            {
                var rødlistedeNaturområder = new List<Naturområde>();

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

                foreach (var naturområdeType in naturområdeTyper)
                {
                    if (rødlisteKlassifisering.Beskrivelsesvariabel.Count <= 0)
                    {
                        rødlistedeNaturområder.Add(naturområdeType.Naturområde);
                        continue;
                    }
                    if (rødlisteKlassifisering.Beskrivelsesvariabel.Count == 1 &&
                        naturområdeType.Beskrivelsesvariabel.Any(d =>
                            d.kode == rødlisteKlassifisering.Beskrivelsesvariabel.First().verdi))
                    {
                        rødlistedeNaturområder.Add(naturområdeType.Naturområde);
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
                    if (allBeskrivelsesvariablerPresent) rødlistedeNaturområder.Add(naturområdeType.Naturområde);
                }

                foreach (var naturområde in rødlistedeNaturområder)
                {
                    if(!rødlistedeNaturområderDict.ContainsKey(rødlisteKlassifisering)) rødlistedeNaturområderDict[rødlisteKlassifisering] = new List<Naturområde>();
                    rødlistedeNaturområderDict[rødlisteKlassifisering].Add(naturområde);
                }
            }
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

            var existingRows = dbSet.Where(predicate);
            if (!existingRows.Any()) return dbSet.Add(entity);

            Context.Entry(existingRows.First()).State = EntityState.Unchanged;
            return existingRows.First();
        }
    }
}

