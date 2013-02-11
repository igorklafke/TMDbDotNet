using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TMDbDotNet.TmdbApi;

namespace TMDbSampleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TMDb tmdb = new TMDb("YOUR-API-KEY");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(tmdb));
        }
    }
}
