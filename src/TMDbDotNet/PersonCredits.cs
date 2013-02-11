using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class PersonCredits
    {
        public int id { get; set; }
        public IEnumerable<PersonCast> cast { get; set; }
        public IEnumerable<PersonCrew> crew { get; set; }
    }
    public class PersonCast
    {
        public int id { get; set; }
        public string title { get; set; }
        public string character { get; set; }
        public string original_title { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public bool adult { get; set; }
    }
    public class PersonCrew
    {
        public int id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public bool adult { get; set; }
    }
}