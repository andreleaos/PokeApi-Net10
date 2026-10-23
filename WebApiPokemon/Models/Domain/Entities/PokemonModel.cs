using System.Text.Json.Serialization;

namespace WebApiPokemon.Models.Domain.Entities
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public List<Ability> Abilities { get; set; } = new();

        [JsonPropertyName("types")]
        public List<PokemonType> PokemonTypes { get; set; } = new();

        [JsonPropertyName("moves")]
        public List<MovesPokemon> Moves { get; set; } = new();

        public string Message { get; set; }

    }

    public class Ability
    {
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
        public int Slot { get; set; }

        [JsonPropertyName("ability")]
        public PokemonObjectItemDetail AbilityInfo  { get; set; }
    }

    public class PokemonType
    {
        public int Slot { get; set; }
        [JsonPropertyName("type")]
        public PokemonObjectItemDetail TypeDetail { get; set; }
    }

    public class PokemonObjectItemDetail
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class MovesPokemon
    {
        [JsonPropertyName("move")]
        public PokemonObjectItemDetail Move { get; set; }

        [JsonPropertyName("version_group_details")]
        public List<VersionGroupDetail> VersionGroupDetail { get; set; }
    }

    public class VersionGroupDetail
    {
        [JsonPropertyName("version_group")]
        public PokemonObjectItemDetail VersionGroup { get; set; }

        [JsonPropertyName("move_learn_method")]
        public PokemonObjectItemDetail MoveLearnMethod { get; set; }

    }
}
