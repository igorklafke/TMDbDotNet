using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieCasts
    {
        public int id { get; set; }
        public IEnumerable<MovieCast> cast { get; set; }
        public IEnumerable<MovieCrew> crew { get; set; }
    }
    public class MovieCast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }
    }
    public class MovieCrew
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string profile_path { get; set; }
    }
}
