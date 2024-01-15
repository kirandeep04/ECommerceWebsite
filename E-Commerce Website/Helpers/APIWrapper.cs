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
        //public async Task<HttpAPIWrapperResponse<R>?> GetAsync<R>(string endpoint)
        //{
        //    var httpAPIWrapperResponse = new HttpAPIWrapperResponse<R>();

        //    var httpClient = _httpClientFactory.CreateClient(Constants.HttpNamedClients.API);

        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //    var response = await httpClient.GetAsync(endpoint, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonResponse = await response.Content.ReadAsStringAsync();
        //        httpAPIWrapperResponse.StatusCode = response.StatusCode;
        //        httpAPIWrapperResponse.IsSuccess = true;
        //        httpAPIWrapperResponse.data = JsonConvert.DeserializeObject<R>(jsonResponse);
        //        return httpAPIWrapperResponse;

        //    }
        //    else
        //    {
        //        httpAPIWrapperResponse.IsSuccess = false;
        //        httpAPIWrapperResponse.StatusCode = response.StatusCode;
        //        return httpAPIWrapperResponse;
        //    }
        //}
        //public async Task<HttpAPIWrapperResponse<R>?> GetAsync<R>(string endpoint)
        //{
        //    var httpAPIWrapperResponse = new HttpAPIWrapperResponse<R>();

        //    var httpClient = _httpClientFactory.CreateClient(Constants.HttpNamedClients.API);

        //    var response = await httpClient.GetAsync(endpoint);

        //    httpAPIWrapperResponse.StatusCode = response.StatusCode;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonResponse = await response.Content.ReadAsStringAsync();
        //        httpAPIWrapperResponse.IsSuccess = true;

        //        // Deserialize to a collection type if R is not a primitive type or a single object
        //        if (typeof(R).IsGenericType && typeof(R).GetGenericTypeDefinition() == typeof(List<>))
        //        {
        //            httpAPIWrapperResponse.data = JsonConvert.DeserializeObject<R>(jsonResponse);
        //        }
        //        else
        //        {
        //            // Handle deserialization for a single object
        //            httpAPIWrapperResponse.data = JsonConvert.DeserializeObject<R>(jsonResponse);
        //        }

        //        return httpAPIWrapperResponse;
        //    }
        //    else
        //    {
        //        httpAPIWrapperResponse.IsSuccess = false;
        //        httpAPIWrapperResponse.StatusCode = response.StatusCode;
        //        return httpAPIWrapperResponse;
        //    }
        //}

        public async Task<HttpAPIWrapperResponse<R>?> GetAsync<R>(string endpoint)
        {
            var httpAPIWrapperResponse = new HttpAPIWrapperResponse<R>();


            var httpClient = _httpClientFactory.CreateClient(Constants.HttpNamedClients.API);

            var response = await httpClient.GetAsync(endpoint);

            httpAPIWrapperResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
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

        public async Task<HttpAPIWrapperResponse<R>?> CreateAsync<T, R>(string endpoint, T data)
        {
            var httpAPIWrapperResponse = new HttpAPIWrapperResponse<R>();

            try
            {
                using (var httpClient = _httpClientFactory.CreateClient(Constants.HttpNamedClients.API))
                {
                    var jsonData = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(endpoint, content);

                    httpAPIWrapperResponse.StatusCode = response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        httpAPIWrapperResponse.IsSuccess = true;
                        httpAPIWrapperResponse.data = JsonConvert.DeserializeObject<R>(jsonResponse);
                    }
                    else
                    {
                        httpAPIWrapperResponse.IsSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, and set appropriate response properties
                httpAPIWrapperResponse.IsSuccess = false;
                // Log or handle the exception according to your needs
            }

            return httpAPIWrapperResponse;
        }
    }
}


    


