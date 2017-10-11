using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Forms_dev3;
using Newtonsoft.Json;

namespace RødlisteKlassifiserer
{
    public static class CodeDeserializer
    {
        private const string KodeVersjonVerdi = "2.1";

        public static void UpdateNaturtypeFromWeb()
        {
            foreach (var code in GetAllCodes("http://webtjenester.artsdatabanken.no/NiN/v2b/koder/alleKoder"))
            {
                var naturområdeType = ConvertToNaturområdeType(code);
                var existingRow = DataConnection.Context.NaturområdeTypeKodeSet.Where(d =>
                    d.Naturnivå.verdi == naturområdeType.Naturnivå.verdi &&
                    d.verdi == naturområdeType.verdi &&
                    d.KodeVersjon.verdi == naturområdeType.KodeVersjon.verdi);

                if (existingRow.Any()) continue;
                DataConnection.Context.NaturområdeTypeKodeSet.Add(naturområdeType);
                DataConnection.Context.SaveChanges();
            }
        }

        public static void UpdateBeskrivelsesvariablerFromWeb()
        {
            foreach (var code in GetAllCodes("http://webtjenester.artsdatabanken.no/NiN/v2b/variasjon/allekoder"))
            {
                var beskrivelsesvariabel = ConvertToBeskrivelsesvariablelType(code);
                var existingRow = DataConnection.Context.BeskrivelsesvariabelSet.Where(d =>
                    d.navn == beskrivelsesvariabel.navn &&
                    d.verdi == beskrivelsesvariabel.verdi);

                if (existingRow.Any()) continue;
                DataConnection.Context.BeskrivelsesvariabelSet.Add(beskrivelsesvariabel);
                DataConnection.Context.SaveChanges();
            }
        }

        private static IEnumerable<JsonCode> GetAllCodes(string url)
        {
            var json = new WebClient {Encoding = Encoding.UTF8}.DownloadString(url);

            var jsonCodeValues = JsonConvert.DeserializeObject<JsonCode[]>(json);

            foreach (var jsonCodeValue in jsonCodeValues)
            {
                if (jsonCodeValue.UnderordnetKoder == null)
                    yield return jsonCodeValue;
            }
        }

        private static NaturområdeTypeKode ConvertToNaturområdeType(JsonCode code)
        {
            var codeSplit = code.Kode["Id"].Split(' ');

            var mappingSplit = codeSplit[1].Split('-');

            var kartlaggingsKode = new KartleggingsKode {nivå = "A", navn = code.Navn};

            var naturNivå= new Naturnivå{ verdi = codeSplit[0] };

            var naturområdeTypeKode = new NaturområdeTypeKode
            {
                KodeVersjon = GetKodeVersjon(),
                Naturnivå = DataConnection.Context.NaturnivåSet.AddIfNotExists(naturNivå, d => d.verdi == naturNivå.verdi),
                verdi = mappingSplit[0]
            };

            if (mappingSplit.Length > 2)
            {
                kartlaggingsKode.nivå = mappingSplit[1];
                kartlaggingsKode.verdi = short.Parse(mappingSplit[2]);
            }
            else if (mappingSplit.Length > 1)
                kartlaggingsKode.verdi = short.Parse(mappingSplit[1]);

            var existingNaturområdeTypeKodes = DataConnection.Context.NaturområdeTypeKodeSet.Where(d =>
                d.verdi == naturområdeTypeKode.verdi &&
                d.Naturnivå.verdi == naturområdeTypeKode.Naturnivå.verdi &&
                d.KodeVersjon.verdi == naturområdeTypeKode.KodeVersjon.verdi);

            if (existingNaturområdeTypeKodes.Any())
            {
                var existingNaturområdeTypeKode = existingNaturområdeTypeKodes.First();
                existingNaturområdeTypeKode.KartleggingsKode.Add(kartlaggingsKode);
                return existingNaturområdeTypeKode;
            }

            naturområdeTypeKode.KartleggingsKode.Add(kartlaggingsKode);

            return naturområdeTypeKode;
        }

        private static KodeVersjon GetKodeVersjon()
        {
            var kodeVersjon = new KodeVersjon {verdi = KodeVersjonVerdi};
            return DataConnection.Context.KodeVersjonSet.AddIfNotExists(kodeVersjon, d => d.verdi == kodeVersjon.verdi);
        }

        private static Beskrivelsesvariabel ConvertToBeskrivelsesvariablelType(JsonCode code)
        {
            return new Beskrivelsesvariabel {verdi = code.Kode["Id"], navn = code.Navn, KodeVersjon = GetKodeVersjon()};
        }
    }
}