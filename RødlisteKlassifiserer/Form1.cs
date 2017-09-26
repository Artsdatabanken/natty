using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Forms_dev3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdateKodelister.Enabled = false;
            CodeDeserializer.UpdateNaturtypeFromWeb();
            CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
            buttonUpdateKodelister.Enabled = true;
        }

        private void textBoxNaturområdetyper_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxNaturområdetyper.Items.Clear();
            using (var context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                foreach (var hit in context.NaturområdeTypeKodeSet.Where(d =>
                    (d.verdi + "-" + d.KartleggingsKode.verdi).StartsWith(textBox1.Text.ToUpper()) &&
                    d.KartleggingsKode.nivå == "A"))
                {
                    checkedListBoxNaturområdetyper.Items.Add(hit.verdi + "-" + hit.KartleggingsKode.verdi);
                }
            }
        }

        private void textBoxBeskrivelsesvariabler_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            using (var context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                foreach (var hit in context.BeskrivelsesvariabelSet.Where(d => d.verdi.StartsWith(textBox2.Text)))
                {
                    checkedListBoxBeskrivelsesvariabler.Items.Add(hit.verdi);
                }
            }
        }

        private void buttonUpdateValideringsenheter_Click(object sender, EventArgs e)
        {
            buttonUpdateValideringsenheter.Enabled = false;
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            var xlApp = new Excel.Application();
            var xlWorkbook = xlApp.Workbooks.Open(path + @"\Data\20170912_RL_2011_nin2_1_oversettelse_ØG.xlsx");
            var xlWorksheet = (Excel.Worksheet) xlWorkbook.Sheets.get_Item(1);
            var xlRange = xlWorksheet.UsedRange;
            var valueArray = (object[,]) xlRange.get_Value(
                Excel.XlRangeValueDataType.xlRangeValueDefault);

            var columns = new Dictionary<int, string>();
            //using (var context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                var parentVurderingsenhet = new RødlisteVurderingsenhet();
                for (var row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
                {
                    var rowValues = new Dictionary<string, string>();
                    for (var col = 1; col <= xlWorksheet.UsedRange.Columns.Count; ++col)
                    {
                        if (row == 1) columns[col] = valueArray[row, col].ToString();
                        else rowValues[columns[col]] = valueArray[row, col]?.ToString();
                    }
                    if (row <= 1) continue;

                    var rødlisteVurderingsenhet = new RødlisteVurderingsenhet
                    {
                        tema = rowValues["Tema"],
                        versjon = rowValues["Rødlisteversjon"],
                        verdi = rowValues["Vurderingsenhet"],
                        kategori = rowValues["Rødlistekategori"],
                        nivå = rowValues["Naturnivå"]
                    };

                    if (rødlisteVurderingsenhet.verdi.StartsWith("*"))
                    {
                        rødlisteVurderingsenhet.verdi = rødlisteVurderingsenhet.verdi.Replace("* ", "");
                        parentVurderingsenhet.children.Add(rødlisteVurderingsenhet); 

                    }
                    else
                    {
                        parentVurderingsenhet = rødlisteVurderingsenhet;
                    }
                    CodeDeserializer.Context.RødlisteVurderingsenhetSet.Add(rødlisteVurderingsenhet);
                }
                CodeDeserializer.Context.SaveChanges();
            }

            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

            buttonUpdateValideringsenheter.Enabled = true;
        }
    }
}
