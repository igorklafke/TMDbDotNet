using System;
using System.Net;
using System.Web.Script.Serialization;

namespace TMDbDotNet.TmdbApi
{
    internal class Utils
    {
        internal static T HttpGet<T>(string uri)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            client.Headers.Add("Content-Type", "application/json");

            try
            {
                string result = client.DownloadString(new Uri(uri));
                return Deserialize<T>(result);
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                client.Dispose();
            }
        }

        internal static void HttpGetAsync<T>(string uri, Action<T> onCompleted = null, Action<Exception> onError = null)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Accept", "application/json");
                client.Headers.Add("Content-Type", "application/json");

                client.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e)
                {
                    if (e.Error != null)
                    {
                        if (onError != null)
                            onError(e.Error);
                    }

                    if (e.Result != null && e.Result.Length > 0)
                    {
                        if (onCompleted != null)
                            onCompleted(Deserialize<T>(e.Result));
                    }
                };

                client.DownloadStringAsync(new Uri(uri));
            }
        }

        internal static T HttpPost<T>(string uri, object json_body)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            client.Headers.Add("Content-Type", "application/json");

            try
            {
                string result = client.UploadString(new Uri(uri), Serialize(json_body));
                return Deserialize<T>(result);
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                client.Dispose();
            }
        }

        internal static T Deserialize<T>(string json)
        {
            var obj = new JavaScriptSerializer().Deserialize<T>(json);
            return obj;
            
        }

        internal static string Serialize(object obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            return json;
        }
    }
}
