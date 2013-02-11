using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieReleases
    {
        public int id { get; set; }
        public IEnumerable<MovieCountryRelease> countries { get; set; }
    }

    public class MovieCountryRelease
    {
        public string iso_3166_1 { get; set; }
        public string certification { get; set; }
        public string release_date { get; set; }
    }
}
