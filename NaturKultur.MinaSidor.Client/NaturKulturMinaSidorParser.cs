using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NaturKultur.MinaSidor
{
    internal static class NaturKulturMinaSidorParser
    {
        public static Dictionary<string, string> ParseLoginForm(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                return new Dictionary<string, string>
                {
                    {
                        "ReturnUrl", doc.DocumentNode.SelectSingleNode("//input[@name='ReturnUrl']").Attributes["value"].Value
                    },
                    {
                        "__RequestVerificationToken", doc.DocumentNode.SelectSingleNode("//input[@name='__RequestVerificationToken']").Attributes["value"].Value
                    }
                };
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find the nodes and attributes in the login HTML.", e);
            }
        }

        public static async Task<Dictionary<string, string>> ParseLoginFormAsync(string html) => await Task.Run(() => ParseLoginForm(html));
    }
}
