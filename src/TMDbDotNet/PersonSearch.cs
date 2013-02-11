using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class PersonSearch
    {
        public int page { get; set; }
        public IEnumerable<Person> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
