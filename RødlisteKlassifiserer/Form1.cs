using System;
using System.Collections.Generic;
using System.Linq;
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
            CodeDeserializer.UpdateNaturtypeFromWeb();
            CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
        }

        private void textBoxNaturområdetyper_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBoxNaturområdetyper.Items.Clear();
            using (var context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                foreach (var hit in context.NaturområdeTypeKodeSet.Where(d => (d.verdi + "-" + d.KartleggingsKode.verdi).StartsWith(textBox1.Text.ToUpper()) && d.KartleggingsKode.nivå == "A"))
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
    }
}
