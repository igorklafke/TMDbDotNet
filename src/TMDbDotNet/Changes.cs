using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class Changes
    {
        public IEnumerable<Change> changes { get; set; }
    }
    public class Change
    {
        public string key { get; set; }
        public IEnumerable<ChangedItem> items { get; set; }
    }
    public class ChangedItem
    {
        public string id { get; set; }
        public string action { get; set; }
        public string time { get; set; }
        public object value { get; set; }
        public string iso_639_1 { get; set; }
    }

    public class ChangeList
    {
        public IEnumerable<ChangedListItem> results { get; set; }
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
    public class ChangedListItem
    {
        public int id { get; set; }
        public bool adult { get; set; }
    }
}
