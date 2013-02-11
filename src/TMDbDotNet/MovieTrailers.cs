using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieTrailers
    {
        public int id { get; set; }
        public Quicktime quicktime { get; set; }
        public Youtube youtube { get; set; }
    }
    public class Quicktime
    {
        //todo: quicktime
    }
    public class Youtube
    {
        public string name { get; set; }
        public string size { get; set; }
        public string source { get; set; }
    }
}
