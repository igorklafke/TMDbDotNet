using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDbDotNet.TmdbApi
{
    public class AuthenticationToken
    {
        public bool success { get; set; }
        public string expires_at { get; set; }
        public string request_token { get; set; }
    }
}