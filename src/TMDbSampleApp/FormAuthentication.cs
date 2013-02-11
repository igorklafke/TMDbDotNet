using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMDbDotNet.TmdbApi;

namespace TMDbSampleApp
{
    public partial class FormAuthentication : Form
    {
        TMDb _tmdb;
        string _token;
        string _sessionId;

        public FormAuthentication(TMDb tmdb)
        {
            InitializeComponent();
            _tmdb = tmdb;
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            AuthenticationToken token = _tmdb.GetAuthenticationToken();
            if (token.success)
            {
                _token = token.request_token;
                ProcessStartInfo p = new ProcessStartInfo("http://www.themoviedb.org/authenticate/" + _token);
                Process.Start(p);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            UserSession usersession = _tmdb.GetUserSession(_token);
            _sessionId = usersession.session_id;
            this.Close();
        }
    }
}
