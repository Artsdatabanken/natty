using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
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
            PopulateAll();
        }

        private void PopulateAll()
        {
            
            buttonUpdateKodelister.Enabled = false;

            if (!CodeDeserializer.Context.NaturområdeTypeKodeSet.Any())
            {
                CodeDeserializer.UpdateNaturtypeFromWeb();
            }
            if (!CodeDeserializer.Context.BeskrivelsesvariabelSet.Any())
            {
                CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
            }
            buttonUpdateKodelister.Enabled = true;

            if (!CodeDeserializer.Context.RødlisteVurderingsenhetSet.Any())
            {
                buttonUpdateValideringsenheter.Enabled = false;
                buttonUpdateValideringsenheter_Click(null, null);
                buttonUpdateValideringsenheter.Enabled = true;
            }
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            foreach (var hit in CodeDeserializer.Context.RødlisteVurderingsenhetSet)
            {
                comboBoxVurderingsenhet.Items.Add(hit.verdi);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdateKodelister.Enabled = false;
            CodeDeserializer.UpdateNaturtypeFromWeb();
            CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
            buttonUpdateKodelister.Enabled = true;
        }

        //private void textBoxNaturområdetyper_KeyUp(object sender, KeyEventArgs e)
        //{
        //    checkedListBoxNaturområdetyper.Items.Clear();
        //    foreach (var hit in CodeDeserializer.Context.NaturområdeTypeKodeSet.Where(d =>
        //        d.verdi.StartsWith(textBox1.Text.ToUpper())))
        //    {
        //        foreach (var kartleggingsKode in hit.KartleggingsKode)
        //        {
        //            if(kartleggingsKode.nivå == "A")
        //                checkedListBoxNaturområdetyper.Items.Add(hit.verdi + "-" + kartleggingsKode.verdi);
        //        }
                
        //    }
        //}

        //private void textBoxBeskrivelsesvariabler_KeyUp(object sender, KeyEventArgs e)
        //{
        //    checkedListBoxBeskrivelsesvariabler.Items.Clear();
        //    foreach (var hit in CodeDeserializer.Context.BeskrivelsesvariabelSet.Where(d =>
        //        d.verdi.StartsWith(textBox2.Text)))
        //    {
        //        checkedListBoxBeskrivelsesvariabler.Items.Add(hit.verdi);
        //    }
        //}

        private void buttonUpdateValideringsenheter_Click(object sender, EventArgs e)
        {
            CodeDeserializer.Context.Database.ExecuteSqlCommand("DELETE FROM [dbo].RødlisteVurderingsenhetSet");
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
                else parentVurderingsenhet = rødlisteVurderingsenhet;

                CodeDeserializer.Context.RødlisteVurderingsenhetSet.Add(rødlisteVurderingsenhet);
            }
            CodeDeserializer.Context.SaveChanges();

            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

            buttonUpdateValideringsenheter.Enabled = true;
        }

        private void comboBoxVurderingsenhet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rødlisteVurderingsenhetSet = CodeDeserializer.Context.RødlisteVurderingsenhetSet.Where(d =>
                d.verdi == comboBoxVurderingsenhet.SelectedItem.ToString());
            if (!rødlisteVurderingsenhetSet.Any()) return;

            foreach (var hit in rødlisteVurderingsenhetSet)
            {
                if (hit.RødlisteKlassifisering == null) continue;

                foreach (var rødlisteKlassifisering in hit.RødlisteKlassifisering)
                {
                    if (rødlisteKlassifisering.KartleggingsKode.Any())
                    {
                        //checkedListBoxNaturområdetyper.Items.Clear();
                        foreach (var kartleggingsKode in rødlisteKlassifisering.KartleggingsKode)
                        {
                            //checkedListBoxNaturområdetyper.Items.Add(kartleggingsKode.NaturområdeTypeKode.verdi + "-" + kartleggingsKode.verdi);

                            var existingNode = treeViewNaturområdeType.Nodes
                                .Find(kartleggingsKode.NaturområdeTypeKode.verdi, false);

                            if (existingNode.Any())
                            {
                                existingNode.First().Nodes.Add(kartleggingsKode.verdi.ToString());
                                continue;
                            }
                            treeViewNaturområdeType.Nodes.Add(kartleggingsKode.NaturområdeTypeKode.verdi).Nodes.Add(kartleggingsKode.verdi.ToString());
                                
                        }
                        //for (var i = 0; i < checkedListBoxNaturområdetyper.Items.Count; i++)
                        //    checkedListBoxNaturområdetyper.SetItemChecked(i, true);
                    }

                    if (!rødlisteKlassifisering.Beskrivelsesvariabel.Any()) continue;

                    checkedListBoxBeskrivelsesvariabler.Items.Clear();
                    foreach (var beskrivelsesvariabel in rødlisteKlassifisering.Beskrivelsesvariabel)
                    {
                        checkedListBoxBeskrivelsesvariabler.Items.Add(beskrivelsesvariabel.verdi);
                    }
                }
                for (var i = 0; i < checkedListBoxBeskrivelsesvariabler.Items.Count; i++)
                    checkedListBoxBeskrivelsesvariabler.SetItemChecked(i, true);

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxVurderingsenhet.SelectedItem == null) return;

            //var selectedNaturområdeTyper = GetSelectedNaturområdeTypeValues();

            var selectedKartleggingsKoder = GetSelectedKartleggingsKoder();

            var selectedBeskrivelsesvariabler = GetSelectedBeskrivelsesvariablerValues();

            var selectedRødlisteVurderingsenhet = GetSelectedRødlisteVurderingsEnhet();

            //var existingRødlisteKlassifisering = CodeDeserializer.Context.RødlisteKlassifiseringSet.First(d => d.RødlisteVurderingsenhet)

            //CodeDeserializer.Context.Entry(selectedRødlisteVurderingsenhet).State = EntityState.Unchanged;

            var rødlisteKlassifisering = new RødlisteKlassifisering
            {
                RødlisteVurderingsenhet = selectedRødlisteVurderingsenhet,
                KartleggingsKode = selectedKartleggingsKoder.ToList(),
                Beskrivelsesvariabel = selectedBeskrivelsesvariabler.ToList()
            };

            CodeDeserializer.Context.RødlisteKlassifiseringSet.Add(rødlisteKlassifisering);

            CodeDeserializer.Context.SaveChanges();

        }

        private IEnumerable<KartleggingsKode> GetSelectedKartleggingsKoder()
        {
            foreach (var node in treeViewNaturområdeType.Nodes)
            {
                var verdi = node.ToString();
                yield return CodeDeserializer.Context.KartleggingsKodeSet.First(d =>
                    d.NaturområdeTypeKode.verdi == verdi);
            }
        }

        private RødlisteVurderingsenhet GetSelectedRødlisteVurderingsEnhet()
        {
            return CodeDeserializer.Context.RødlisteVurderingsenhetSet.First(d =>
                d.verdi == comboBoxVurderingsenhet.SelectedItem.ToString());
        }

        private IEnumerable<Beskrivelsesvariabel> GetSelectedBeskrivelsesvariablerValues()
        {
            return from object selectedBeskrivelsesvariabel in checkedListBoxBeskrivelsesvariabler.CheckedItems select CodeDeserializer.Context.BeskrivelsesvariabelSet.First(d => d.verdi == selectedBeskrivelsesvariabel.ToString());
        }

        //private IEnumerable<NaturområdeTypeKode> GetSelectedNaturområdeTypeValues()
        //{
        //    throw new NotImplementedException();
        //    //return checkedListBoxNaturområdetyper.CheckedItems.Cast<object>()
        //    //    .Select(selectedNaturområdeTypeConcat => new
        //    //    {
        //    //        selectedNaturområdeTypeConcat,
        //    //        selectedNaturområdeType = selectedNaturområdeTypeConcat.ToString().Split('-')[0]
        //    //    })
        //    //    .Select(@t => new
        //    //    {
        //    //        @t,
        //    //        selectedKartleggingsKode = @t.selectedNaturområdeTypeConcat.ToString().Split('-')[1]
        //    //    })
        //    //    .Select(@t => CodeDeserializer.Context.NaturområdeTypeKodeSet.Where(d =>
        //    //        d.verdi == @t.@t.selectedNaturområdeType))
        //    //    .Select(selectedNaturområdeTypeKode => selectedNaturområdeTypeKode.First());
        //}
    }
}
