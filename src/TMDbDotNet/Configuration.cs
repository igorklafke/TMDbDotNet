using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Configuration
    {
        public Images images { get; set; }
    }
    
    public class Images
    {
        public string base_url { get; set; }
        public IEnumerable<string> poster_sizes { get; set; }
        public IEnumerable<string> backdrop_sizes { get; set; }
        public IEnumerable<string> profile_sizes { get; set; }
        public IEnumerable<string> logo_sizes { get; set; }
    }
}
