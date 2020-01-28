using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using webapi;
using Xunit;

namespace integrationtests
{
    public class ControllerTests
    {
        private TestServer server;
        private HttpClient client;

        public ControllerTests()
        {
            var builder = new WebHostBuilder()
              .UseStartup<Startup>()
              .UseEnvironment("Development");

            server = new TestServer(builder);

            client = server.CreateClient();
        }

        [Fact]
        public async Task Get_Pesel_ReturnsOk()
        {
            // Act
            var response = await client.GetAsync("api/customers/9531204591");

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        
    }
}
