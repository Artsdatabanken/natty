using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Forms_dev3
{
    public static class CodeDeserializer
    {
        public static readonly RødlistedeNaturtyperKlassifiseringContainer Context =
            new RødlistedeNaturtyperKlassifiseringContainer();

        public static void UpdateNaturtypeFromWeb()
        {
            foreach (var code in GetAllCodes("http://webtjenester.artsdatabanken.no/NiN/v2b/koder/alleKoder"))
            {
                var naturområdeType = ConvertToNaturområdeType(code);
                var existingRow = Context.NaturområdeTypeKodeSet.Where(d =>
                    d.KartleggingsKode.verdi == naturområdeType.KartleggingsKode.verdi &&
                    d.KartleggingsKode.nivå == naturområdeType.KartleggingsKode.nivå &&
                    d.nivå == naturområdeType.nivå &&
                    d.verdi == naturområdeType.verdi &&
                    d.versjon == naturområdeType.versjon);

                if(existingRow.Any()) continue;
                Context.NaturområdeTypeKodeSet.Add(naturområdeType);
                Context.SaveChanges();
            }
        }

        public static void UpdateBeskrivelsesvariablerFromWeb()
        {
            foreach (var code in GetAllCodes("http://webtjenester.artsdatabanken.no/NiN/v2b/variasjon/allekoder"))
            {
                var beskrivelsesvariabel = ConvertToBeskrivelsesvariablelType(code);
                var existingRow = Context.BeskrivelsesvariabelSet.Where(d =>
                    d.navn == beskrivelsesvariabel.navn);

                if (existingRow.Any()) continue;
                Context.BeskrivelsesvariabelSet.Add(beskrivelsesvariabel);
                Context.SaveChanges();
            }
        }

        private static IEnumerable<JsonCode> GetAllCodes(string url)
        {
            var json = new WebClient { Encoding = Encoding.UTF8 }.DownloadString(url);

            var jsonCodeValues = JsonConvert.DeserializeObject<JsonCode[]>(json);

            foreach (var jsonCodeValue in jsonCodeValues)
            {
                if (jsonCodeValue.UnderordnetKoder == null) yield return jsonCodeValue;
            }
        }

        private static NaturområdeTypeKode ConvertToNaturområdeType(JsonCode code)
        {
            var codeSplit = code.Kode["Id"].Split(' ');
            var mappingSplit = codeSplit[1].Split('-');

            var naturområdeTypeKode = new NaturområdeTypeKode
            {
                KartleggingsKode = new KartleggingsKode { verdi = -1, nivå = "A" },
                versjon = "2.1",
                nivå = codeSplit[0],
                verdi = mappingSplit[0],
                navn = code.Navn
            };

            if (mappingSplit.Length > 2)
            {
                naturområdeTypeKode.KartleggingsKode.nivå = mappingSplit[1];
                naturområdeTypeKode.KartleggingsKode.verdi = short.Parse(mappingSplit[2]);
            }
            else if (mappingSplit.Length > 1)
                naturområdeTypeKode.KartleggingsKode.verdi = short.Parse(mappingSplit[1]);

            naturområdeTypeKode.KartleggingsKode = Context.KartleggingsKodeSet.AddIfNotExists(naturområdeTypeKode.KartleggingsKode, d =>
                d.verdi == naturområdeTypeKode.KartleggingsKode.verdi &&
                d.nivå == naturområdeTypeKode.KartleggingsKode.nivå);

            return naturområdeTypeKode;
        }

        private static Beskrivelsesvariabel ConvertToBeskrivelsesvariablelType(JsonCode code)
        {
            return new Beskrivelsesvariabel {verdi = code.Kode["Id"], navn = code.Navn};
        }

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