using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieTranslations
    {
        public int id { get; set; }
        public IEnumerable<Translation> translations { get; set; }
    }
    public class Translation
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
        public string english_name { get; set; }
    }
}
