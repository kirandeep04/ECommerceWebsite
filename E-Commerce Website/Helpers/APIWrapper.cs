using E_Commerce_Website.Models;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce_Website.Helpers
{
    public class HttpAPIWrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HttpAPIWrapper(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<HttpAPIWrapperResponse<R>?> PostAsync<R, T>(string endpoint, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            return await PostAsync<R>(endpoint, jsonData);
        }
        public async Task<HttpAPIWrapperResponse<R>?> PostAsync<R>(string endpoint, string jsonData)
        {
            var httpAPIWrapperResponse = new HttpAPIWrapperResponse<R>();

            var httpClient = _httpClientFactory.CreateClient(Constants.HttpNamedClients.API);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(endpoint, content);
            
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                httpAPIWrapperResponse.StatusCode = response.StatusCode;
                httpAPIWrapperResponse.IsSuccess = true;
                httpAPIWrapperResponse.data = JsonConvert.DeserializeObject<R>(jsonResponse);
                return httpAPIWrapperResponse;

            }
            else
            {
                httpAPIWrapperResponse.IsSuccess = false;
                httpAPIWrapperResponse.StatusCode = response.StatusCode;
                return httpAPIWrapperResponse;
            }

        }

    }
}

