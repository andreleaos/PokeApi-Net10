using System.Net.Http.Headers;
using WebApiPokemon.Services;

namespace WebApiPokemon.IoC
{
    public static class Startup
    {
        public static  void Configure(IConfiguration configuration, IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureHttpClient(configuration, services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPokemonService, PokemonService>();
        }

        private static void ConfigureHttpClient(IConfiguration configuration, IServiceCollection services)
        {
            string _urlBase = configuration["ExternalApis:PokemonApi"]
                ?? throw new InvalidOperationException(
                    "URl da PokeAPi não foi configurada");

            int timeoutParam = Int32.Parse(configuration.GetSection("Timeout").Value);

            services.AddHttpClient("PokeApi", client =>
            {
                client.BaseAddress = new Uri(_urlBase);

                client.Timeout = TimeSpan.FromSeconds(timeoutParam);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
