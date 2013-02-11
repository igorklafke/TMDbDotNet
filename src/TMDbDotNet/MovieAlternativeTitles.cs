using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieAlternativeTitles
    {
        public int id { get; set; }
        public IEnumerable<MovieAlternativeTitle> titles { get; set; }
    }
    public class MovieAlternativeTitle
    {
        public string iso_3166_1 { get; set; }
        public string title { get; set; }
    }
}