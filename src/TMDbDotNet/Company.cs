using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Company
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string headquarters { get; set; }
        public string homepage { get; set; }
        public Company parent_company { get; set; }
    }

    public class CompanySearch
    {
        public int page { get; set; }
        public IEnumerable<Company> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}