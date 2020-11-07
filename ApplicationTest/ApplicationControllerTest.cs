using Application;
using Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest
{
    public class ApplicationControllerTest
    {
        private TestServer server;
        private HttpClient client;
    
        public ApplicationControllerTest()
        {
            var host = new WebHostBuilder().UseStartup<Startup>();

            server = new TestServer(host);
            client = server.CreateClient();
        }

        public static ApplicationModel InitializeMock()
        {
            return new ApplicationModel()
            {
                ApplicationId = 8,
                Url = "www.softdesign.com.br",
                PathLocal = "inetpub\\wwwroot",
                DebuggingMode = false
            };
        }

        [Test]
        public async Task InitializeAPITests()
        {
            ApplicationModel appModel = InitializeMock();
            await GetApplicationList();
            await GetApplicationById(appModel.ApplicationId);
            await InsertNewApplication(appModel);
            await UpdateApplication(appModel);
            await DeleteApplication(appModel.ApplicationId);
        }

        private async Task GetApplicationList()
        {
            string response = await client.GetStringAsync("/api/application");
        }

        private async Task GetApplicationById(int id)
        {
            string response = await client.GetStringAsync($"/api/application/{id}");
        }

        private async Task InsertNewApplication(ApplicationModel appModel)
        {

            StringContent request = new StringContent(JsonConvert.SerializeObject(appModel), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/application/", request);

            response.EnsureSuccessStatusCode();
        }

        private async Task UpdateApplication(ApplicationModel appModel)
        {

            StringContent request = new StringContent(JsonConvert.SerializeObject(appModel), Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("/api/application/", request);

            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteApplication(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/application/{id}");
        }
    }
}