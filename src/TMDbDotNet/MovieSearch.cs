using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieSearch
    {
        public int page { get; set; }
        public IEnumerable<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
