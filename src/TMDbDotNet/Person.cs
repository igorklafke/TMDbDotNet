using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Person
    {
        public bool adult { get; set; }
        public IEnumerable<string> also_known_as { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public string deathday { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path { get; set; }
    }
}