using System.ComponentModel.DataAnnotations;

namespace Daniel_VU_API.Dto.Pokemon;

public class PokemonAddRequest
{
    public string Name { get; set; }

    [Range(1, 100)]
    public int Level { get; set; }
}
