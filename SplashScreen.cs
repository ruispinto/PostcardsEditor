using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostcardsEditor.myclass;

namespace PostcardsEditor
{
    public partial class SplashScreen : Form
    {
        dataclass dc = new dataclass();

        Timer tmr;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lbl_softwareVersion.Text = "Version " + dc.sVersion;
            string greetingText = "";

            if (DateTime.Now.Hour < 12)
                greetingText = "Good Morning";
            else if (DateTime.Now.Hour < 18)
                greetingText = "Good Afternoon";
            else
                greetingText = "Good Night";
            
            lbl_greeting.Text = greetingText + " Rui";

        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();

            //set time interval 3 sec
            tmr.Interval = 3000;

            //starts the timer
            tmr.Start();

            tmr.Tick += tmr_Tick;
            
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();

            //display DataEditor form
            Form form = new DataViewer();
            form.Show();

            //hide this form
            this.Hide();

        }
    }
}
