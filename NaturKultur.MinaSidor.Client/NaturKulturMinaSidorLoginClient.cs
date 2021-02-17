using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace NaturKultur.MinaSidor
{
    internal class NaturKulturMinaSidorLoginClient : IDisposable, INaturKulturMinaSidorLoginClient
    {
        NaturKulturMinaSidorClient _parent;
        HttpClient _httpClient;

        public NaturKulturMinaSidorLoginClient(NaturKulturMinaSidorClient parent)
        {
            _parent = parent;

            HttpClientHandler handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                CookieContainer = parent.CookieContainer,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://login.nok.se")
            };
        }

        public async Task<bool> TryAuthenticateAsync(string username, string password)
        {
            // Start by getting the front page

            var response = await _parent.HttpClient.GetAsync("/mina-sidor");

            response.EnsureSuccessStatusCode();

            if (response.RequestMessage.RequestUri.Host != "login.nok.se")
                throw new Exception("Wasn't redirected to login.nok.se.");

            var loginHtml = await response.Content.ReadAsStringAsync();

            var tokens = NaturKulturMinaSidorParser.ParseLoginForm(loginHtml);

            tokens.Add("Username", username);
            tokens.Add("Password", password);

            var content = new FormUrlEncodedContent(tokens);

            var loginRequest = new HttpRequestMessage(HttpMethod.Post, response.RequestMessage.RequestUri) { Content = content };
            loginRequest.Headers.Referrer = response.RequestMessage.RequestUri;

            var loginResponse = await _httpClient.SendAsync(loginRequest);

            if (!loginResponse.Headers.Contains("Location") || !loginResponse.Headers.Location.OriginalString.StartsWith("/connect/authorize/callback"))
                return false;

            var redirectUri = loginResponse.Headers.Location.ToString().Replace("&amp;", "&");

            var authReponse = await _httpClient.GetAsync(redirectUri);

            if (authReponse.StatusCode != HttpStatusCode.OK)
                return false;

            var callbackHtml = await authReponse.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(callbackHtml);
            var portalSigninLocation = doc.DocumentNode.SelectSingleNode("//form").GetAttributeValue("action", "");

            var inputNodes = doc.DocumentNode.SelectNodes("//input").Select(n => new KeyValuePair<string, string>(n.GetAttributeValue("name", ""), n.GetAttributeValue("value", "")));

            var portalSigninContent = new FormUrlEncodedContent(inputNodes);

            var portalSignInResponse = await _httpClient.PostAsync(portalSigninLocation, portalSigninContent);

            var responseLocation = portalSignInResponse.Headers.Location?.ToString();

            return responseLocation == "https://portal.nok.se/mina-sidor";
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
