using Newtonsoft.Json;
using WebApiPokemon.Models.Domain.Entities;

namespace WebApiPokemon.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PokemonModel> Pesquisar(string nome)
        {
            var httpClient = _httpClientFactory.CreateClient("PokeApi");

            string endpoint = string.Format("pokemon/{0}", nome);

            try
            {
                var pokemonResult = await httpClient
                    .GetFromJsonAsync<PokemonModel>(endpoint);

                return pokemonResult;

            }
            catch (Exception ex)
            {
                throw new Exception("Pokemon Não localizado");
            }
        }
    }
}
