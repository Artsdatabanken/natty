using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
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

        private readonly Dictionary<string, Dictionary<short?, bool>> _selectedDictionary =
            new Dictionary<string, Dictionary<short?, bool>>();

        private void PopulateAll()
        {

            buttonUpdateKodelister.Enabled = false;

            if (!DataConnection.Context.NaturområdeTypeKodeSet.Any())
            {
                CodeDeserializer.UpdateNaturtypeFromWeb();
            }
            if (!DataConnection.Context.BeskrivelsesvariabelSet.Any())
            {
                CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
            }
            buttonUpdateKodelister.Enabled = true;

            if (!DataConnection.Context.RødlisteVurderingsenhetSet.Any())
            {
                buttonUpdateValideringsenheter.Enabled = false;
                buttonUpdateValideringsenheter_Click(null, null);
                buttonUpdateValideringsenheter.Enabled = true;
            }
            PopulateComboBox();

            PopulateNaturområdeCheckList();
        }

        private void PopulateNaturområdeCheckList()
        {
            foreach (var naturområdeType in DataConnection.Context.NaturområdeTypeKodeSet)
            {
                checkedListBoxNaturområdetyper.Items.Add(naturområdeType.verdi);
            }
        }

        private void PopulateComboBox()
        {
            foreach (var hit in DataConnection.Context.RødlisteVurderingsenhetSet)
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

        private void buttonUpdateValideringsenheter_Click(object sender, EventArgs e)
        {
            DataConnection.Context.Database.ExecuteSqlCommand("DELETE FROM [dbo].RødlisteVurderingsenhetSet");
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

                DataConnection.Context.RødlisteVurderingsenhetSet.Add(rødlisteVurderingsenhet);
            }
            DataConnection.Context.SaveChanges();

            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

            buttonUpdateValideringsenheter.Enabled = true;
        }

        //private void textBoxNaturområdetyper_KeyUp(object sender, KeyEventArgs e)
        //{
        //    checkedListBoxNaturområdetyper.Items.Clear();
        //    foreach (var hit in DataConnection.Context.NaturområdeTypeKodeSet.Where(d =>
        //        d.verdi.StartsWith(textBox1.Text.ToUpper())))
        //    {
        //        foreach (var kartleggingsKode in hit.KartleggingsKode)
        //        {
        //            if (kartleggingsKode.nivå == "A")
        //                checkedListBoxNaturområdetyper.Items.Add(hit.verdi + "-" + kartleggingsKode.verdi);
        //        }

        //    }
        //}

        private void textBoxBeskrivelsesvariabler_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            foreach (var hit in DataConnection.Context.BeskrivelsesvariabelSet.Where(d =>
                d.verdi.StartsWith(textBox2.Text)))
            {
                checkedListBoxBeskrivelsesvariabler.Items.Add(hit.verdi);
            }
        }

        private void comboBoxVurderingsenhet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllCheckBoxes();
            PopulateNaturområdeCheckList();

            var rødlisteVurderingsenhetSet = DataConnection.Context.RødlisteVurderingsenhetSet.Where(d =>
                d.verdi == comboBoxVurderingsenhet.SelectedItem.ToString());
            if (!rødlisteVurderingsenhetSet.Any()) return;

            foreach (var hit in rødlisteVurderingsenhetSet)
            {
                if (hit.RødlisteKlassifisering == null) continue;

                foreach (var rødlisteKlassifisering in hit.RødlisteKlassifisering)
                {
                    if (rødlisteKlassifisering.KartleggingsKode.Any())
                    {
                        foreach (var kartleggingsKode in rødlisteKlassifisering.KartleggingsKode)
                        {
                            AddKartleggingsKode2Dictionary(kartleggingsKode, true);
                        }
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

        private void ClearAllCheckBoxes()
        {
            checkedListBoxNaturområdetyper.Items.Clear();
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            checkedListBoxKartleggingsKode.Items.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxVurderingsenhet.SelectedItem == null) return;

            var selectedKartleggingsKoder = GetSelectedKartleggingsKoder();

            var selectedBeskrivelsesvariabler = GetSelectedBeskrivelsesvariablerValues();

            var selectedRødlisteVurderingsenhet = GetSelectedRødlisteVurderingsEnhet();

            var rødlisteKlassifisering = new RødlisteKlassifisering
            {
                RødlisteVurderingsenhet = selectedRødlisteVurderingsenhet,
                KartleggingsKode = selectedKartleggingsKoder.ToList(),
                Beskrivelsesvariabel = selectedBeskrivelsesvariabler.ToList()
            };

            DataConnection.Context.RødlisteKlassifiseringSet.Add(rødlisteKlassifisering);

            DataConnection.Context.SaveChanges();

        }

        private IEnumerable<KartleggingsKode> GetSelectedKartleggingsKoder()
        {
            foreach (var naturområdeTypeEntry in _selectedDictionary)
            {
                foreach (var kartleggingsKodeEntry in naturområdeTypeEntry.Value)
                {
                    if (kartleggingsKodeEntry.Value)
                        yield return DataConnection.Context.KartleggingsKodeSet.First(d =>
                            d.NaturområdeTypeKode.verdi == naturområdeTypeEntry.Key &&
                            d.verdi == kartleggingsKodeEntry.Key);
                }
            }
        }

        private RødlisteVurderingsenhet GetSelectedRødlisteVurderingsEnhet()
        {
            return DataConnection.Context.RødlisteVurderingsenhetSet.First(d =>
                d.verdi == comboBoxVurderingsenhet.SelectedItem.ToString());
        }

        private IEnumerable<Beskrivelsesvariabel> GetSelectedBeskrivelsesvariablerValues()
        {
            return from object selectedBeskrivelsesvariabel in checkedListBoxBeskrivelsesvariabler.CheckedItems
                select DataConnection.Context.BeskrivelsesvariabelSet.First(d =>
                    d.verdi == selectedBeskrivelsesvariabel.ToString());
        }

        private void checkedListBoxNaturområdetyper_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNaturområdeTypeKode = GetSelectedNaturområdeType();
            checkedListBoxKartleggingsKode.Items.Clear();

            if (_selectedDictionary.ContainsKey(selectedNaturområdeTypeKode.verdi))
            {
                foreach (var kartleggingsKode in _selectedDictionary[selectedNaturområdeTypeKode.verdi])
                {
                    checkedListBoxKartleggingsKode.Items.Add(kartleggingsKode.Key, kartleggingsKode.Value);
                }
            }
            else
                foreach (var kartleggingsKode in selectedNaturområdeTypeKode.KartleggingsKode)
                {
                    if (kartleggingsKode.nivå != "A") continue;
                    checkedListBoxKartleggingsKode.Items.Add(kartleggingsKode.verdi);

                    AddKartleggingsKode2Dictionary(kartleggingsKode);
                }
        }

        private void AddKartleggingsKode2Dictionary(KartleggingsKode kartleggingsKode, bool standardValue = false)
        {
            if (!_selectedDictionary.ContainsKey(kartleggingsKode.NaturområdeTypeKode.verdi))
                _selectedDictionary[kartleggingsKode.NaturområdeTypeKode.verdi] =
                new Dictionary<short?, bool> { [kartleggingsKode.verdi] = standardValue };
            _selectedDictionary[kartleggingsKode.NaturområdeTypeKode.verdi][kartleggingsKode.verdi] = standardValue;
        }

        private NaturområdeTypeKode GetSelectedNaturområdeType()
        {
            return DataConnection.Context.NaturområdeTypeKodeSet.First(d =>
                            d.verdi == checkedListBoxNaturområdetyper.SelectedItem.ToString());
        }

        private void checkedListBoxKartleggingsKode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxKartleggingsKode.SelectedItem == null) return;
            var selectedNaturområdeTypeKode = GetSelectedNaturområdeType();
            var shortKartleggingskode = (short) checkedListBoxKartleggingsKode.SelectedItem;
            _selectedDictionary[selectedNaturområdeTypeKode.verdi][shortKartleggingskode] =
                e.NewValue == CheckState.Checked;
        }
    }
}