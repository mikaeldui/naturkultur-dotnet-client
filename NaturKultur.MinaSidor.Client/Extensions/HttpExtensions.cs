using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaturKultur.MinaSidor
{
    internal static class HttpExtensions
    {
        public static async Task<T> ReadAsObjectAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }
    }
}
