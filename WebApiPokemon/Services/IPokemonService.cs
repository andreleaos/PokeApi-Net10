using WebApiPokemon.Models.Domain.Entities;

namespace WebApiPokemon.Services
{
    public interface IPokemonService
    {
        Task<PokemonModel> Pesquisar(string nome);
    }
}
