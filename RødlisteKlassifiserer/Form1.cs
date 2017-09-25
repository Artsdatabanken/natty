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

        private void button1_Click(object sender, EventArgs e)
        {
            CodeDeserializer.UpdateNaturtypeFromWeb();
            CodeDeserializer.UpdateBeskrivelsesvariablerFromWeb();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBox1.Items.Clear();
            using (var Context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                foreach (var hit in Context.NaturområdeTypeKodeSet.Where(d => (d.verdi + "-" + d.KartleggingsKode.verdi).StartsWith(textBox1.Text.ToUpper()) && d.KartleggingsKode.nivå == "A"))
                {
                    checkedListBox1.Items.Add(hit.verdi + "-" + hit.KartleggingsKode.verdi);
                }
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            checkedListBox2.Items.Clear();
            using (var Context = new RødlistedeNaturtyperKlassifiseringContainer())
            {
                foreach (var hit in Context.BeskrivelsesvariabelSet.Where(d => d.verdi.StartsWith(textBox2.Text)))
                {
                    checkedListBox2.Items.Add(hit.verdi);
                }
            }
        }
    }
}
