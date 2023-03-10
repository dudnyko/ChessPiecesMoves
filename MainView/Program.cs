using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          Label:
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto Label;
            }
        }
    }
}
