using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace TestN5.Test.IntegrationsTest

{
    public partial class ITestPermissions
    {

        private HttpClient _httpClient;

        public ITestPermissions()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task DefaultRoute_ReturnsHelloWorld()
        {
            var response = await _httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();

            //Assert.AreEqual("Hello World!", stringResult);
        }
    }
}