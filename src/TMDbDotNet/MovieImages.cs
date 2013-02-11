using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class MovieImages
    {
        public int id { get; set; }
        public IEnumerable<Image> backdrops { get; set; }
        public IEnumerable<Image> posters { get; set; }
    }
}