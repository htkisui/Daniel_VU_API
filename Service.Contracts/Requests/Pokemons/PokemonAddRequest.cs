using System.ComponentModel.DataAnnotations;

namespace Service.Contracts.Requests.Pokemons;

public class PokemonAddRequest
{
    public string Name { get; set; }

    [Range(1, 100)]
    public int Level { get; set; }
    public int TrainerId { get; set; }
}
