using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace TestN5.Integration
{
    public class ApiTests
    {

        private HttpClient _httpClient;

        public ApiTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task Test1Async()
        {
            var response = await _httpClient.GetAsync("");
        }
    }
}