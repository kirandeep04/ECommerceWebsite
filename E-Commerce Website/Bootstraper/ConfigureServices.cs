using E_Commerce_Website.Helpers;

namespace E_Commerce_Website.Bootstraper
{
    public static class ConfigureServices
    {
        public static void AddHttpNamedClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(Constants.HttpNamedClients.API, c =>
            {
                c.BaseAddress = new Uri(configuration["Settings.APIBaseUrl"]);

                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
