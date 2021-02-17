using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturKultur.MinaSidor.Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        /// <summary>
        /// You can set it in PowerShell using [Environment]::SetEnvironmentVariable("NATURKULTUR_MINASIDOR_USERNAME", "firstname.lastname@domain.com", 'User').
        /// Visual Studio probably needs to be restarted after doing it.
        /// </summary>
        private static readonly string USERNAME = Environment.GetEnvironmentVariable("NATURKULTUR_MINASIDOR_USERNAME");
        /// <summary>
        /// You can set it in PowerShell using [Environment]::SetEnvironmentVariable("NATURKULTUR_MINASIDOR_PASSWORD", "SuperSecret123", 'User')
        /// Visual Studio probably needs to be restarted after doing it.
        /// </summary>
        private static readonly string PASSWORD = Environment.GetEnvironmentVariable("NATURKULTUR_MINASIDOR_PASSWORD");

        [TestMethod]
        public async Task EverythingAsync()
        {
            using (var client = new NaturKulturMinaSidorClient())
            {
                var success = await client.TryAuthenticateAsync(USERNAME, PASSWORD);

                Assert.IsTrue(success, "Login failed.");

                var user = await client.GetUserAsync();

                Assert.IsNotNull(user);
            }
        }
    }
}
