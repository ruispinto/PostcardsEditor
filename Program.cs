using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostcardsEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// Application.Run(new SplashScreen());
            /// Application.Run(new SeriesViewer());
             Application.Run(new DataViewer());
            /// Application.Run(new OtherOptions());
            /// Application.Run(new About());
        }
    }
}
