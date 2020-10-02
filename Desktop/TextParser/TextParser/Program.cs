using System;
using System.Windows.Forms;

namespace TextParser
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        public static string _RootPath = Properties.Settings.Default.RootPath; // "D:\\GitHubRepo\\EsercizioMBB\\Desktop\\TextParser\\Test";
        public static string _HeaderSymbol = Properties.Settings.Default.HeaderSymbol; //"->";
       
    }
}
