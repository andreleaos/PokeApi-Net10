using Microsoft.AspNetCore.Mvc;
using WebApiPokemon.Models.Domain.Entities;
using WebApiPokemon.Services;

namespace WebApiPokemon.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _service;

        public PokemonController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Index()
        {
            return "Api Pokemon";
        }

        [HttpGet]
        [Route("{nome}")]
        public async Task<PokemonModel> Pesquisar(string nome)
        {
            try
            {
                var pokemon = await _service.Pesquisar(nome);
                return pokemon;
            }
            catch(Exception ex)
            {
                return new PokemonModel() { Message = ex.Message };
            }
        }
    }
}
