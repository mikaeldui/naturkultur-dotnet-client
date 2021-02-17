using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NaturKultur.Onlineboken
{
    public class NaturKulturOnlinebokenClient : IDisposable
    {
        private HttpClient _httpClient;

        public NaturKulturOnlinebokenClient(Uri frontPage, System.Net.CookieContainer cookieContainer)
        {
            _httpClient = new HttpClient();
        }

        public NaturKulturDigitalbokReader GetDigitalbokReader(Uri bokUri)
        {
              //  https://online.nok.se/bok/9789127436398/index.html
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
