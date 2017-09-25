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
    }
}
