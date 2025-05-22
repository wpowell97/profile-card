using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProfileCardApp.Models;

namespace ProfileCardApp.Services
{
    public class HubSpotService
    {
        private readonly HubSpotSettings _settings;
        private readonly HttpClient _httpClient;

        public HubSpotService(IOptions<HubSpotSettings> options)
        {
            _settings = options.Value;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _settings.ApiToken);
        }

        public async Task SubmitFormAsync(ContactFormViewModel model)
        {
            var endpoint = $"https://api.hsforms.com/submissions/v3/integration/submit/{_settings.PortalId}/{_settings.FormId}";

            var submission = new
            {
                fields = new[]
                {
                    new { name = "email", value = model.Email },
                    new { name = "firstname", value = model.Name },
                    new { name = "message", value = model.Message }
                }
            };

            var json = JsonConvert.SerializeObject(submission);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode(); // Will throw if not 2xx
        }
    }
}
