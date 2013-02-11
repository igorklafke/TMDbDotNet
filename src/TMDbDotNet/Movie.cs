using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public Collection belongs_to_collection { get; set; }
        public int budget { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public IEnumerable<Company> production_companies { get; set; }
        public IEnumerable<Country> production_countries { get; set; }
        public string release_date { get; set; }
        public Int64 revenue { get; set; }
        public int runtime { get; set; }
        public IEnumerable<Language> spoken_languages { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }

    
}
