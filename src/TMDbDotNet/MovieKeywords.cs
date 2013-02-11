using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieKeywords
    {
        public int id { get; set; }
        public IEnumerable<Keyword> keywords { get; set; }
    }
    public class Keyword
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
