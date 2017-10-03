using System;
using System.Collections.Generic;
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
            MaximumSize = Size;
            MinimumSize = Size;
            PopulateAll();
        }

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

            PopulateNaturnivåCombobox();

            PopulateVurderingsenhetComboBox();

            PopulateNaturområdeComboBox();

            PopulateBeskrivelsesVariabler();
        }

        private void PopulateNaturnivåCombobox()
        {
            foreach (var naturnivå in DataConnection.Context.NaturnivåSet)
            {
                comboBoxNaturnivå.Items.Add(naturnivå.verdi);
            }

            comboBoxNaturnivå.SelectedItem = "NA";
        }

        private void PopulateBeskrivelsesVariabler(ICollection<string> beskrivelsesvariabler = null)
        {
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            if (checkBoxShowAllBeskrivelsesvariabel.Checked)
                foreach (var beskrivelsesvariabel in DataConnection.Context.BeskrivelsesvariabelSet.OrderBy(
                    d => d.verdi))
                {
                    if (beskrivelsesvariabler != null)
                        checkedListBoxBeskrivelsesvariabler.Items.Add(beskrivelsesvariabel.verdi,
                            beskrivelsesvariabler.Contains(beskrivelsesvariabel.verdi));
                    else
                        checkedListBoxBeskrivelsesvariabler.Items.Add(beskrivelsesvariabel.verdi);
                }
            else
            {
                if (beskrivelsesvariabler == null) return;
                foreach (var beskrivelsesvariabel in beskrivelsesvariabler)
                {
                    checkedListBoxBeskrivelsesvariabler.Items.Add(beskrivelsesvariabel, true);
                }
            }
        }

        private void PopulateInnsnevrendeBeskrivelsesVariabler(ICollection<string> beskrivelsesvariabler = null)
        {
            checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Clear();
            if (checkBoxInnsnevrendeBeskrivelsesvariabel.Checked)
                foreach (var beskrivelsesvariabel in DataConnection.Context.BeskrivelsesvariabelSet.OrderBy(
                    d => d.verdi))
                {
                    if (beskrivelsesvariabler != null)
                        checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Add(beskrivelsesvariabel.verdi,
                            beskrivelsesvariabler.Contains(beskrivelsesvariabel.verdi));
                    else
                        checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Add(beskrivelsesvariabel.verdi);
                }
            else
            {
                if (beskrivelsesvariabler == null) return;
                foreach (var beskrivelsesvariabel in beskrivelsesvariabler)
                {
                    checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Add(beskrivelsesvariabel, true);
                }
            }
        }

        private void PopulateNaturområdeComboBox()
        {
            foreach (var naturområdeType in DataConnection.Context.NaturområdeTypeKodeSet)
            {
                comboBoxNaturområdetyper.Items.Add(naturområdeType.verdi);
            }
        }

        private void PopulateVurderingsenhetComboBox()
        {
            foreach (var hit in DataConnection.Context.RødlisteVurderingsenhetSet
                .Where(d => d.Naturnivå.verdi == comboBoxNaturnivå.SelectedItem.ToString()).OrderBy(d => d.Id))
            {
                comboBoxVurderingsenhet.Items.Add(hit.verdi);
            }
        }

        private void PopulateKartleggingsKoder(string naturområdeType, ICollection<string> kartleggingsKoder = null)
        {
            var selectedNaturområdeTypeKode = GetSelectedNaturområdeType(naturområdeType);
            checkedListBoxKartleggingsKode.Items.Clear();
            var kartleggingsKodeList = new List<KartleggingsKode>();

            foreach (var kartleggingsKode in selectedNaturområdeTypeKode.KartleggingsKode)
            {
                if (kartleggingsKode.nivå != "A") continue;
                if (kartleggingsKode.verdi == null) continue;
                kartleggingsKodeList.Add(kartleggingsKode);

            }
            foreach (var kartleggingsKode in kartleggingsKodeList)
            {
                if (kartleggingsKoder != null)
                    checkedListBoxKartleggingsKode.Items.Add(kartleggingsKode.verdi,
                        kartleggingsKoder.Contains(kartleggingsKode.verdi.ToString()));
                else
                    checkedListBoxKartleggingsKode.Items.Add(kartleggingsKode.verdi);
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
                    RødlisteVurdeingsenhetVersjon =
                        DataConnection.Context.RødlisteVurdeingsenhetVersjonSet.AddIfNotExists(
                            new RødlisteVurdeingsenhetVersjon {verdi = rowValues["Rødlisteversjon"]}),
                    verdi = rowValues["Vurderingsenhet"],
                    kategori = rowValues["Rødlistekategori"],
                    Naturnivå = DataConnection.Context.NaturnivåSet.AddIfNotExists(new Naturnivå
                    {
                        verdi = rowValues["Naturnivå"]
                    })
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

        private void textBoxBeskrivelsesvariabler_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            foreach (var hit in DataConnection.Context.BeskrivelsesvariabelSet.Where(d =>
                d.verdi.StartsWith(textBoxBeskrivelsesvaiabler.Text)))
            {
                checkedListBoxBeskrivelsesvariabler.Items.Add(hit.verdi);
            }
        }

        private void comboBoxVurderingsenhet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllCheckBoxes();
            PopulateNaturområdeComboBox();
            UpdateGridView();
        }

        private void ClearAllCheckBoxes()
        {
            checkedListBoxBeskrivelsesvariabler.Items.Clear();
            checkedListBoxKartleggingsKode.Items.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxVurderingsenhet.SelectedItem == null) return;

            var selectedKartleggingsKoder = GetSelectedKartleggingsKoder();

            var selectedBeskrivelsesvariabler = GetSelectedBeskrivelsesvariablerValues();

            var selectedRødlisteVurderingsenhet = GetSelectedRødlisteVurderingsEnhet();

            var selectedInnsnevrendeBeskrivelsesvariabler = GetSelectedInnsnevrendeBeskrivelsesvariablerValues();



            if (checkBoxPermutations.Checked)
            {

                
                if (!selectedKartleggingsKoder.Any())
                    selectedKartleggingsKoder = DataConnection.Context.NaturområdeTypeKodeSet.First(d =>
                        d.verdi == comboBoxNaturområdetyper.SelectedItem).KartleggingsKode;


                var beskrivelsesVariabelDictionary = new Dictionary<string, List<Beskrivelsesvariabel>>();
                foreach (var beskrivelsesvariabel in selectedBeskrivelsesvariabler.ToList())
                {
                    var key = beskrivelsesvariabel.verdi.Split('_')[0];
                    if(!beskrivelsesVariabelDictionary.ContainsKey(key)) beskrivelsesVariabelDictionary[key] = new List<Beskrivelsesvariabel>();
                    beskrivelsesVariabelDictionary[key].Add(beskrivelsesvariabel);
                }

                

                foreach (var kartlegginsKode in selectedKartleggingsKoder.ToList())
                {
                    var addedDict = new Dictionary<Tuple<Beskrivelsesvariabel, Beskrivelsesvariabel>, bool>();
                    if (beskrivelsesVariabelDictionary.Keys.Count > 0)
                        foreach (var uniqueBeskrivelsesvariabel1 in beskrivelsesVariabelDictionary)
                        {
                            foreach (var uniqueBeskrivelsesvariabel2 in beskrivelsesVariabelDictionary)
                            {
                                if (uniqueBeskrivelsesvariabel1.Key == uniqueBeskrivelsesvariabel2.Key) continue;
                                foreach (var beskrivelsesvariabel1 in uniqueBeskrivelsesvariabel1.Value)
                                {
                                    foreach (var beskrivelsesvariabel2 in uniqueBeskrivelsesvariabel2.Value)
                                    {
                                        if (beskrivelsesvariabel1.Id == beskrivelsesvariabel2.Id) continue;
                                        var tupleKey = new Tuple<Beskrivelsesvariabel, Beskrivelsesvariabel>(beskrivelsesvariabel1, beskrivelsesvariabel2);
                                        var tupleKeyReversed = new Tuple<Beskrivelsesvariabel, Beskrivelsesvariabel>(beskrivelsesvariabel2, beskrivelsesvariabel1);
                                        if (addedDict.ContainsKey(tupleKey) || addedDict.ContainsKey(tupleKeyReversed))
                                            continue;
                                        var rødlisteKlassifisering = new RødlisteKlassifisering
                                        {
                                            KartleggingsKode = new List<KartleggingsKode> {kartlegginsKode},
                                            RødlisteVurderingsenhet = selectedRødlisteVurderingsenhet,
                                            Beskrivelsesvariabel = new List<Beskrivelsesvariabel> {beskrivelsesvariabel1, beskrivelsesvariabel2}
                                        };
                                        if (selectedInnsnevrendeBeskrivelsesvariabler.Any())
                                            rødlisteKlassifisering.InnsnevrendeBeskrivelsesvariabel =
                                                selectedInnsnevrendeBeskrivelsesvariabler.ToList();
                                        DataConnection.Context.RødlisteKlassifiseringSet.Add(rødlisteKlassifisering);
                                        addedDict[tupleKey] = true;
                                    }
                                }
                            }
                        }
                    else
                    {
                        var rødlisteKlassifisering = new RødlisteKlassifisering
                        {
                            KartleggingsKode = new List<KartleggingsKode> {kartlegginsKode},
                            RødlisteVurderingsenhet = selectedRødlisteVurderingsenhet
                        };


                        if (checkedListBoxInnsnevrendeBeskrivelsesvariabel.CheckedItems.Count != 0)
                            rødlisteKlassifisering.InnsnevrendeBeskrivelsesvariabel =
                                selectedInnsnevrendeBeskrivelsesvariabler.ToList();
                        DataConnection.Context.RødlisteKlassifiseringSet.Add(rødlisteKlassifisering);
                    }
                }
            }
            else
            {
                var rødlisteKlassifisering = new RødlisteKlassifisering();
                if (!selectedKartleggingsKoder.Any())
                    rødlisteKlassifisering.NaturområdeTypeKode =
                        DataConnection.Context.NaturområdeTypeKodeSet.First(d =>
                            d.verdi == comboBoxNaturområdetyper.SelectedItem);

                else
                    rødlisteKlassifisering.KartleggingsKode = selectedKartleggingsKoder.ToList();

                rødlisteKlassifisering.RødlisteVurderingsenhet = selectedRødlisteVurderingsenhet;
                rødlisteKlassifisering.Beskrivelsesvariabel = selectedBeskrivelsesvariabler.ToList();

                if (checkedListBoxInnsnevrendeBeskrivelsesvariabel.CheckedItems.Count != 0)
                    rødlisteKlassifisering.InnsnevrendeBeskrivelsesvariabel =
                        selectedInnsnevrendeBeskrivelsesvariabler.ToList();
                DataConnection.Context.RødlisteKlassifiseringSet.Add(rødlisteKlassifisering);
            }



            DataConnection.Context.SaveChanges();

            UpdateGridView();

        }

        private IEnumerable<Beskrivelsesvariabel> GetSelectedInnsnevrendeBeskrivelsesvariablerValues()
        {
            foreach (string innsnevrendeBeskrivelsesvariabel in checkedListBoxInnsnevrendeBeskrivelsesvariabel
                .CheckedItems)
            {
                if(innsnevrendeBeskrivelsesvariabel == "") continue;
                yield return DataConnection.Context.BeskrivelsesvariabelSet.First(d =>
                    d.verdi == innsnevrendeBeskrivelsesvariabel);
            }
        }

        private void UpdateGridView()
        {
            dataGridViewRødlisteKlassifisering.Rows.Clear();
            foreach (var rødlisteVurderingsenhet in DataConnection.Context.RødlisteVurderingsenhetSet.Where(d =>
                d.verdi == comboBoxVurderingsenhet.SelectedItem.ToString()))
            {
                foreach (var rødlisteKlassifisering in rødlisteVurderingsenhet.RødlisteKlassifisering)
                {
                    var naturområdeTyper = "";
                    if (rødlisteKlassifisering.NaturområdeTypeKode != null)
                    {
                        naturområdeTyper = rødlisteKlassifisering.NaturområdeTypeKode.verdi;
                    }
                    else if (rødlisteKlassifisering.KartleggingsKode.Count > 0)
                    {
                        naturområdeTyper = ConcatinateNaturområdetyper(rødlisteKlassifisering.KartleggingsKode);
                    }

                    var innsnevrendeBeskrivelsesvariabler = "";
                    if (rødlisteKlassifisering.InnsnevrendeBeskrivelsesvariabel.Count > 0)
                        innsnevrendeBeskrivelsesvariabler =
                            ConcatinateInnsnevrendeBeskrivelsesvariabler(rødlisteKlassifisering
                                .InnsnevrendeBeskrivelsesvariabel);
                    var dataGridRow = new DataGridViewRow
                    {
                        Cells =
                        {
                            new DataGridViewTextBoxCell
                            {
                                Value = naturområdeTyper
                            },
                            new DataGridViewTextBoxCell
                            {
                                Value = ConcatinateBeskrivelsesvariabel(rødlisteKlassifisering.Beskrivelsesvariabel)

                            },
                            new DataGridViewTextBoxCell
                            {
                                Value = rødlisteKlassifisering.Id
                            },
                            new DataGridViewTextBoxCell
                            {
                                Value = innsnevrendeBeskrivelsesvariabler
                            }
                        }
                    };
                    dataGridViewRødlisteKlassifisering.Rows.Add(dataGridRow);
                }
            }

            labelAntallKlasser.Text = dataGridViewRødlisteKlassifisering.Rows.Count.ToString();
        }

        private string ConcatinateInnsnevrendeBeskrivelsesvariabler(
            ICollection<Beskrivelsesvariabel> InnsnevrendeBeskrivelsesvariabler)
        {
            var concatinatedString = "";
            foreach (var innsnevrendeBeskrivelsesvariabel in InnsnevrendeBeskrivelsesvariabler)
            {
                concatinatedString += innsnevrendeBeskrivelsesvariabel.verdi + ",";
            }
            return concatinatedString.TrimEnd(',');
        }

        private string ConcatinateNaturområdetyper(ICollection<KartleggingsKode> KartleggingsKodeList)
        {
            var concatinatedString = KartleggingsKodeList.First().NaturområdeTypeKode.verdi + "-";
            foreach (var kartleggingsKode in KartleggingsKodeList)
            {
                concatinatedString += kartleggingsKode.verdi + ",";
            }
            return concatinatedString.TrimEnd(',');
        }

        private string ConcatinateBeskrivelsesvariabel(ICollection<Beskrivelsesvariabel> beskrivelsesvariabelList)
        {
            var concatinatedString = "";
            foreach (var beskrivelsesvariabel in beskrivelsesvariabelList)
            {
                concatinatedString += beskrivelsesvariabel.verdi + ",";
            }
            return concatinatedString.TrimEnd(',');
        }

        private IEnumerable<KartleggingsKode> GetSelectedKartleggingsKoder()
        {
            foreach (var kartleggingsKodeEntry in checkedListBoxKartleggingsKode.CheckedItems)
            {
                var shortValue = (short) kartleggingsKodeEntry;
                yield return DataConnection.Context.KartleggingsKodeSet.First(d =>
                    d.NaturområdeTypeKode.verdi == comboBoxNaturområdetyper.SelectedItem.ToString() &&
                    d.verdi == shortValue);

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

        private NaturområdeTypeKode GetSelectedNaturområdeType(string naturområdeType)
        {
            return DataConnection.Context.NaturområdeTypeKodeSet.First(d =>
                d.verdi == naturområdeType);
        }

        private void comboBoxNaturområdetyper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNaturområdetyper.Text == "") return;
            PopulateKartleggingsKoder(comboBoxNaturområdetyper.Text);
        }

        private void dataGridViewRødlisteKlassifisering_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRødlisteKlassifisering.SelectedRows.Count > 1) return;
            foreach (DataGridViewRow row in dataGridViewRødlisteKlassifisering.SelectedRows)
            {
                if (row.Cells["NaturområdeTyper"].Value == row.Cells["Beskrivelsesvariabler"].Value) return;
                var naturområdeTypeSplit = row.Cells["NaturområdeTyper"].Value.ToString().Split('-');
                var naturområdeType = naturområdeTypeSplit[0];

                var activeIndex = comboBoxNaturområdetyper.Items.IndexOf(naturområdeType);
                comboBoxNaturområdetyper.SelectedIndex = activeIndex;

                List<string> kartleggingsKoder = null;

                if (naturområdeTypeSplit.Length > 1) kartleggingsKoder = naturområdeTypeSplit[1].Split(',').ToList();

                if (naturområdeType != "")
                    PopulateKartleggingsKoder(naturområdeType, kartleggingsKoder);

                var beskrivelsesvariabler = row.Cells["Beskrivelsesvariabler"].Value.ToString().Split(',');

                PopulateBeskrivelsesVariabler(beskrivelsesvariabler);

                var innsnevrendeBeskrivelsesvariabler =
                    row.Cells["InnsnevrendeBeskrivelsesvariabel"].Value.ToString().Split(',');

                PopulateInnsnevrendeBeskrivelsesVariabler(innsnevrendeBeskrivelsesvariabler);
            }
        }

        private void buttonDeleteRødlisteKlassifisering_Click(object sender, EventArgs e)
        {
            if (dataGridViewRødlisteKlassifisering.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow row in dataGridViewRødlisteKlassifisering.SelectedRows)
            {
                var rødlisteKlassifisering =
                    DataConnection.Context.RødlisteKlassifiseringSet.Find((int) row.Cells["RødlisteKlassifisering_id"]
                        .Value);
                DataConnection.Context.RødlisteKlassifiseringSet.Remove(rødlisteKlassifisering);
            }
            DataConnection.Context.SaveChanges();
            UpdateGridView();

        }

        private void buttonUpdateRødlisteKlassifisering_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            if (dataGridViewRødlisteKlassifisering.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow row in dataGridViewRødlisteKlassifisering.SelectedRows)
            {
                var rødlisteKlassifisering =
                    DataConnection.Context.RødlisteKlassifiseringSet.Find((int) row.Cells["RødlisteKlassifisering_id"]
                        .Value);

                DataConnection.Context.SaveChanges();
                UpdateGridView();
            }
        }

        private void checkBoxShowAllBeskrivelsesvariabel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedListBoxBeskrivelsesvariabler.CheckedItems.Count == 0)
            {
                PopulateBeskrivelsesVariabler();
                return;
            }
            var beskrivelsesvariabler = new List<string>();
            foreach (var beskrivelsesvariabel in checkedListBoxBeskrivelsesvariabler.CheckedItems)
            {
                beskrivelsesvariabler.Add(beskrivelsesvariabel.ToString());
            }
            PopulateBeskrivelsesVariabler(beskrivelsesvariabler);
        }

        private void textBoxInnsnevrendeBeskrivelsesvariabel_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Clear();
            foreach (var hit in DataConnection.Context.BeskrivelsesvariabelSet.Where(d =>
                d.verdi.StartsWith(textBoxInnsnevrendeBeskrivelsesvariabel.Text)))
            {
                checkedListBoxInnsnevrendeBeskrivelsesvariabel.Items.Add(hit.verdi);
            }
        }

        private void checkBoxInnsnevrendeBeskrivelsesvariabel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedListBoxInnsnevrendeBeskrivelsesvariabel.CheckedItems.Count == 0)
            {
                PopulateInnsnevrendeBeskrivelsesVariabler();
                return;
            }
            var beskrivelsesvariabler = new List<string>();
            foreach (var beskrivelsesvariabel in checkedListBoxInnsnevrendeBeskrivelsesvariabel.CheckedItems)
            {
                beskrivelsesvariabler.Add(beskrivelsesvariabel.ToString());
            }
            PopulateInnsnevrendeBeskrivelsesVariabler(beskrivelsesvariabler);
        }
    }
}