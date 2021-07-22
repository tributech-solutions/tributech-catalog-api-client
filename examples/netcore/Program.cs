using System;
using System.Threading.Tasks;
using System.Net.Http;
using Tributech.Dsk.Api.Clients;
using Tributech.Dsk.Api.Clients.CatalogApi;

namespace Tributech.Dataspace.ClientExamples {
    class Program {
        // Api Client Configs:

        // Your Node URL (replace "your-node" with the name of your node)
        private const string nodeUrl = "https://catalog-api.your-node.dataspace-node.com";
        // Your Hub URL (replace "your-hub" with the name of your hub and "your-node" with the name of your node)
        private const string tokenUrl = "https://auth.your-hub.dataspace-hub.com/auth/realms/your-node/protocol/openid-connect/token";
        // the scope setting defines what parts of an api / endpoints should be accessible
        // in this case it is catalog-api for the Catalog API.
        private const string scope = "profile email catalog-api node-id";
        // The following two settings can be found in the DataSpace Admin App (Profile -> Administration)
        private const string clientId = "<your-api-specific-client-id>";
        private const string clientSecret = "<your-api-specific-api-client-secret>";

        static async Task Main(string[] args) {
            var authHandler = new APIAuthHandler(tokenUrl, scope, clientId, clientSecret);
            using (var authorizedHttpClient = new HttpClient(authHandler)) {
                authorizedHttpClient.BaseAddress = new Uri(nodeUrl);
                var apiClient = new CatalogAPIClient(authorizedHttpClient);

                // Get all stored models
                var data = await apiClient.GetAllEntitiesAsync(100, 0);

                foreach (var item in data.Data)
                {
                    Console.WriteLine($"{item.Model.Id}: DisplayName {item.Model.DisplayName}");
                }
            }
        }
    }
}
