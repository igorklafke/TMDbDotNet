using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMDbDotNet.TmdbApi;

namespace TMDbSampleApp
{
    public partial class FormMain : Form
    {
        TMDb _tmdb;
        Configuration _config;

        public FormMain(TMDb tmdb)
        {
            InitializeComponent();
            _tmdb = tmdb;
            _config = _tmdb.GetConfiguration();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            FormAuthentication formAuth = new FormAuthentication(_tmdb);
            formAuth.ShowDialog();
        }

        private void btnMovieSearch_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch(_tmdb);
            formSearch.Height = 298;
            formSearch.ShowDialog();
        }
    }
}
