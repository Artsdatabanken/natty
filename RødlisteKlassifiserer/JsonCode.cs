using System.Collections.Generic;

namespace RødlisteKlassifiserer
{
    public class JsonCode
    {
        public string Navn;
        public string Kategori;
        public Dictionary<string, string> Kode;
        public string ElementKode;
        public Dictionary<string, string> OverordnetKode;
        public List<Dictionary<string, string>> UnderordnetKoder;
        public string Beskrivelse;
    }
}