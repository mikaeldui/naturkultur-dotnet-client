using NaturKultur.Onlineboken;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NaturKultur.MinaSidor
{
    public class NaturKulturMinaSidorClient : IDisposable, INaturKulturMinaSidorLoginClient
    {
        internal CookieContainer CookieContainer;
        internal HttpClientHandler HttpClientHandler;
        internal HttpClient HttpClient;

        public NaturKulturMinaSidorClient()
        {
            HttpClientHandler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = CookieContainer ??= new CookieContainer(),
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            HttpClient = new HttpClient(HttpClientHandler) { BaseAddress = new Uri("https://portal.nok.se") };
        }

        public async Task<NaturKulturMinaSidorUser> GetUserAsync()
        {
            var response = await HttpClient.GetAsync("https://portal.nok.se/api/abo/user/me");

            _ensureSuccess(response);

            return await response.Content.ReadAsObjectAsync<NaturKulturMinaSidorUser>();
        }

        /// <summary>
        /// Strange name, it returns an array.
        /// </summary>
        /// <param name="userId">Get it from GetUserAsync().</param>
        public async Task<NaturKulturService[]> GetServiceAsync(int userId)
        {
            var response = await HttpClient.GetAsync($"https://portal.nok.se/api/abo/user/{userId}/service?serviceType=Everything&requireLicense=true&useOptimized=false");

            _ensureSuccess(response);

            return await response.Content.ReadAsObjectAsync<NaturKulturService[]>();
        }

        public async Task<NaturKulturOnlinebokenClient> GetOnlinebokenClient(string serviceStartUrl)
        {
            // Something like https://digital.nok.se/web/site-542896/state-jurdcnztgmra/front-page?session=eyJtYXRlcmlhbCI6IjE3MzMiLCJzZXNzaW9uIjoiNzk2MjU4NzUiLCJhY3Rpb24iOiJ2aWV3IiwidXNlcklkIjoiNTc2Njk3OCIsInRpbWVzdGFtcCI6IjE2MTM1Mjk3MzExMTIifQ%3D%3D&mac=wnL5gy7u4BdtdZ3CagK7okOJQi0%3D
            Uri frontPage;

            return new NaturKulturOnlinebokenClient(frontPage, CookieContainer);
        }

        private static void _ensureSuccess(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var requestUri = response.RequestMessage.RequestUri;

            if (requestUri.Host == "login.nok.se" && requestUri.AbsoluteUri == "/connect/authorize")
                throw new Exception("Redirected to login.");
        }

        public void Dispose() => HttpClient.Dispose();

        public async Task<bool> TryAuthenticateAsync(string username, string password)
        {
            using (var loginClient = new NaturKulturMinaSidorLoginClient(this))
                return await loginClient.TryAuthenticateAsync(username, password);
        }
    }
}
