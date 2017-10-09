﻿using System;
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

                List<Naturområde> naturområder = null;

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
                        naturområder = GetNaturområder(naturområdeTypeKodeVerdi).ToList();
                    }
                }

                if (naturområder == null) continue;

                CheckNaturområdeTypeForBeskrivelsesvariabel(rødlisteKlassifisering, naturområder);


            }
            RødlisteKlassifiserer.DataConnection.Context.SaveChanges();
        }

        private static void SaveRødlistedeNaturområder(RødlisteKlassifisering rødlisteKlassifisering,
            Naturområde naturområde)
        {
            RødlisteKlassifiserer.DataConnection.Context.Naturområde_RødlisteKlassifiseringSet.Add(
                new Naturområde_RødlisteKlassifisering
                {
                    naturområde_id = naturområde.id,
                    RødlisteKlassifisering = rødlisteKlassifisering
                });
        }

        private static void CheckNaturområdeTypeForBeskrivelsesvariabel(RødlisteKlassifisering rødlisteKlassifisering,
            IEnumerable<Naturområde> naturområder)
        {
            foreach (var naturområde in naturområder)
            {
                if (rødlisteKlassifisering.Beskrivelsesvariabel.Count <= 0)
                {
                    SaveRødlistedeNaturområder(rødlisteKlassifisering, naturområde);
                    continue;
                }
                if (rødlisteKlassifisering.Beskrivelsesvariabel.Count == 1)
                    if (naturområde.Beskrivelsesvariabel.Any(d =>
                        d.kode == rødlisteKlassifisering.Beskrivelsesvariabel.First().verdi))
                    {
                        SaveRødlistedeNaturområder(rødlisteKlassifisering, naturområde);
                        continue;
                    }
                    else continue;

                var allBeskrivelsesvariablerPresent = true;
                foreach (var beskrivelsesvariabel in rødlisteKlassifisering.Beskrivelsesvariabel)
                {
                    if (naturområde.Beskrivelsesvariabel.Any(d => d.kode == beskrivelsesvariabel.verdi))
                        continue;
                    allBeskrivelsesvariablerPresent = false;
                    break;
                }
                if (allBeskrivelsesvariablerPresent)
                    SaveRødlistedeNaturområder(rødlisteKlassifisering, naturområde);
            }
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