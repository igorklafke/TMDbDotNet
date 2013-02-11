using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TMDbDotNet.TmdbApi;

namespace TMDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TMDb tmdb = new TMDb("YOUR-API-KEY");

            TestAsyncAuthentication(tmdb);

        }

        static void TestAsyncAuthentication(TMDb tmdb)
        {
            string _token = "";
            Console.Write("Requesting Token");
            tmdb.GetAuthenticationTokenAsync(delegate(AuthenticationToken token)
            {
                Console.WriteLine(token.request_token);
                _token = token.request_token;
                ProcessStartInfo p = new ProcessStartInfo("http://www.themoviedb.org/authenticate/" + token.request_token);
                Process.Start(p);
            });

            //Wait for the token
            while (_token.Length == 0)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }

            Console.Write("Token OK. Press Enter to continue.");
            Console.ReadLine();

            string _sessionID = "";
            Console.Write("Starting session");
            tmdb.GetUserSessionAsync(_token, delegate(UserSession userSession)
            {
                _sessionID = userSession.session_id;
            });

            //Wait for the session
            while (_sessionID.Length == 0)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }

            Console.Write(string.Format("Session ID: {0}, Press Enter to continue.", _sessionID));
            Console.ReadLine();

            //Invoke a method that requires a valid session
            Account act = tmdb.GetAccount();
            Console.WriteLine(act.username);
            Console.ReadLine();
        }
    }
}
