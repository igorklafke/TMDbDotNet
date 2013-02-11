using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class PersonImages
    {
        public int id { get; set; }
        public IEnumerable<Image> profiles { get; set; }
    }
}
