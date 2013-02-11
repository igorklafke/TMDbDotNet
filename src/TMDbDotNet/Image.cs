using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Image
    {
        public string file_path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public double aspect_ratio { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }
}
