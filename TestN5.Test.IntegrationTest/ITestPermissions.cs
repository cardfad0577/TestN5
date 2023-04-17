using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestN5.Test.IntegrationTest
{
    [TestClass]
    public class ITestPermissions
    {

        private HttpClient _httpClient;

        public ITestPermissions()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task TestMethod1Async()
        {
            var response = await _httpClient.GetAsync("GetPermissions");
        }
    }
}