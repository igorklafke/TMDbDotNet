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
    public partial class FormSearch : Form
    {
        TMDb _tmdb;
        Configuration _config;
        int selectedMovieId;

        public FormSearch(TMDb tmdb)
        {
            InitializeComponent();
            _tmdb = tmdb;
            _config = _tmdb.GetConfiguration();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textSearch.Text))
            {
                MovieSearch movies = _tmdb.SearchMovies(textSearch.Text);

                if (movies.total_results > 0)
                {
                    moviesGrid.DataSource = movies.results.Select(m => new
                    {
                        id = m.id,
                        title = m.title,
                        original_title = m.original_title,
                        release_date = m.release_date
                    }).ToList();

                    selectedMovieId = movies.results.First().id;
                    LoadMovieDetails();
                    
                    gbDetails.Visible = true;
                    this.Height = 473;
                }
                else
                {
                    MessageBox.Show("Nothing found", "Search Movies");
                }

            }
        }

        private void LoadMovieDetails()
        {
            Movie movie = _tmdb.GetMovie(selectedMovieId);
            if (movie.poster_path != null)
                picturePoster.Load(_config.images.base_url + _config.images.poster_sizes.First() + movie.poster_path);

            lbTitle.Text = movie.title;
            if (movie.release_date != null)
                lbReleaseDate.Text = movie.release_date;
            if (movie.overview != null)
                lbOverview.Text = movie.overview;

            btnCast.Enabled = true;
            btnFavorite.Enabled = true;
            btnWatchList.Enabled = true;
            btnRate.Enabled = true;
        }

        private void moviesGrid_Click(object sender, EventArgs e)
        {
            int row = moviesGrid.CurrentRow.Index;
            selectedMovieId = Convert.ToInt32(moviesGrid[0, row].Value);

            LoadMovieDetails();
            
        }

        private void btnCast_Click(object sender, EventArgs e)
        {
            MovieCasts casts = _tmdb.GetMovieCasts(selectedMovieId);
            FormCastCrew frmCast = new FormCastCrew(casts);
            frmCast.Text = lbTitle.Text + " - Cast and Crew";
            frmCast.ShowDialog();
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            if (_tmdb.SessionExists())
            {
                Account act = _tmdb.GetAccount();
                _tmdb.AddRemoveFavoriteMovie(act.id, selectedMovieId);
                MessageBox.Show("Succesfully added to favorite list", "Add Favorite");
            }
            else
            {
                FormAuthentication formAuth = new FormAuthentication(_tmdb);
                formAuth.ShowDialog();
            }
        }

        private void btnWatchList_Click(object sender, EventArgs e)
        {
            if (_tmdb.SessionExists())
            {
                Account act = _tmdb.GetAccount();
                _tmdb.AddRemoveMovieWatchlist(act.id, selectedMovieId);
                MessageBox.Show("Succesfully added to watch list", "Add Movie to Watchlist");
            }
            else
            {
                FormAuthentication formAuth = new FormAuthentication(_tmdb);
                formAuth.ShowDialog();
            }
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            if (_tmdb.SessionExists())
            {
                _tmdb.AddMovieRating(selectedMovieId, (double)numberRate.Value);
                MessageBox.Show("Succesfully rated movie", "Rate Watchlist");
            }
            else
            {
                FormAuthentication formAuth = new FormAuthentication(_tmdb);
                formAuth.ShowDialog();
            }
        }
    }
}
