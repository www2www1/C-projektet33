using System;
using System.Windows.Forms;

namespace projektet
{
    [Flags]
    public enum Kategori
    {
        Konst = 1,
        Komedi = 2,
        Utbildning = 4,
        Spel = 8,
        Hälsa = 16,
        Musik = 32,
        Politik = 64,
        Samhälle = 128,
        Sport = 256,
        Teknologi = 512,
        Skräck=1024,
    }

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
            Application.Run(new Form1());
        }
    }
}
