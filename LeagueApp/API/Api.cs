using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace LeagueApp.API
{
    class Api
    {
        private string Key { get; set; }
        private string Region { get; set; }

        public Api(string region)
        {
            Region = region;
            Key = GetKey("Key.txt");
        }
        protected HttpResponseMessage GET(string URL)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();
                return result.Result;
            }
        }
        protected List<HttpResponseMessage> GET(List<string> URLList)
        {
            using (HttpClient client = new HttpClient())
            {
                List<HttpResponseMessage> resultList = new List<HttpResponseMessage>();
                foreach(var URL in URLList)
                {
                    var result = client.GetAsync(URL);
                    resultList.Add(result.Result);
                }
                return resultList;
            }
        }
        protected string GetURL(string path)
        {
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }
        public string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
