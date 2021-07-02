using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostcardsEditor.myclass;

namespace PostcardsEditor
{
    public partial class About : Form
    {
        dataclass dc = new dataclass();

        public About()
        {
            InitializeComponent();
            string softVersion = dc.sVersion;
            string dataVersion = dc.dVersion;
            lbl_softwareVersion.Text = "Version " + softVersion + " (" + dataVersion + ")";
        }

        private void btn_closeAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
