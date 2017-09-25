using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace RødlistedeNaturområder
{
    public class CodeDeserializer
    {
        public static Dictionary<string, NaturområdeTypeCode> GetAllCodes(string url)
        {
            var json = new WebClient().DownloadString(url);

            var jsonCodeValues = JsonConvert.DeserializeObject<JsonCode[]>(json);

            var codeList = (from jsonCodeValue in jsonCodeValues where jsonCodeValue.UnderordnetKoder == null select jsonCodeValue.Kode["Id"]).ToList();

            var typeCodes = new Dictionary<string, NaturområdeTypeCode>();

            foreach (var code in codeList)
            {
                typeCodes[code] = ConvertToNaturområdeType(code);
            }

            return typeCodes;
        }

        private static NaturområdeTypeCode ConvertToNaturområdeType(string code)
        {
            var mappingCode = -1;
            var mappingLevel = "A";

            var prefix = code.Split(' ')[0];
            var value = code.Split(' ')[1].Split('-')[0];

            var mappingPart = code.Split(' ')[1].Split('-');

            if (mappingPart.Length <= 1)
                return new NaturområdeTypeCode
                {
                    Prefix = prefix,
                    Value = value,
                    MappingCode = (short)mappingCode,
                    MappingLevel = mappingLevel
                };

            if (mappingPart.Length > 2)
            {
                mappingLevel = mappingPart[1];
                mappingCode = int.Parse(mappingPart[2]);
            }
            else
                mappingCode = int.Parse(mappingPart[1]);

            return new NaturområdeTypeCode
            {
                Prefix = prefix,
                Value = value,
                MappingCode = (short)mappingCode,
                MappingLevel = mappingLevel
            };
        }
    }

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

    public class NaturområdeTypeCode
    {
        public string Prefix;
        public string Value;
        public string MappingLevel;
        public short MappingCode;
    }
}
