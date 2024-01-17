using System.ComponentModel.DataAnnotations;

namespace Services.Contracts.Requests.Pokemon;

public class PokemonAddRequest
{
    public string Name { get; set; }

    [Range(1, 100)]
    public int Level { get; set; }
}
