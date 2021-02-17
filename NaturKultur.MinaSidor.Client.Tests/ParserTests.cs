using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace NaturKultur.MinaSidor.Client.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public async Task ParseLoginAsync()
        {
            var html = await SampleData.SampleDataHelper.GetStringAsync("Login.html");

            var result = NaturKulturMinaSidorParser.ParseLoginForm(html);

            Assert.AreEqual(result["ReturnUrl"], "/connect/authorize/callback?client_id=portal.nok.se&amp;redirect_uri=https%3A%2F%2Fportal.nok.se%2Fsignin-oidc&amp;response_type=code%20id_token&amp;scope=openid%20naturochkultur%20login%20aboservices%20orders&amp;response_mode=form_post&amp;nonce=637491070071713590.MTE0NTQyNjctOWEzMi00ZTlhLTlhNDctMzYzODI4MzAzZDI5ZGZhZmNmMDgtYTUxNC00Y2ZiLWI5ODktYTI4NzFkMTJmODNl&amp;login_hint&amp;state=CfDJ8BKqhpCXDm1MoLwhzW61IrelSAtQL0v1NoCrJ-SPVMWQ6_-_3om_OD5Y5o-RkpABgDtPFeDv7h2OTv3hNOIBtnmqRltmLg90cFpm6NjMPSAUErnA3nLl9S4FlF_s0MgO2pbtYRokyyA9Myl6vzNsjWkMVfQ8xUju030BALaehM8AXTBGQXvb2fsEn9zbb4LAuRmTgo0TyqO1S7wO2_SIrBLOVlAvuQBzYjZxdtwRp09MOuiHpFggfRSy2ecnSW6JDbClC3K2MyP2vnXBQfUosygwlwnsd2UzVaXXyYTZYaCF0Ycubv13V-BEphqUJM1Q2Jyy9r2hpkXHvtEoCoEsM7k&amp;x-client-SKU=ID_NETSTANDARD1_4&amp;x-client-ver=5.2.0.0");
            Assert.AreEqual(result["__RequestVerificationToken"], "CfDJ8MdoJ0JXdpBBp-Q2tIASt5S5rdd-qjmTS27PmK6jmDTxm3IdRmrmjtYws3nCNnc-_Xbwl3acHnoEKyhVTQ2TVwW8yKRecz0VAE8aRkTBtH9rjCJCygmDVCGirHjW2n3BSn22EhSGdX_qq0hmZGczedM");
        }
    }
}
