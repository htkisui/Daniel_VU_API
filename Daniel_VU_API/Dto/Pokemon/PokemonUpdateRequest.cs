using System.ComponentModel.DataAnnotations;

namespace Daniel_VU_API.Dto.Pokemon;

public class PokemonUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Range(0, 100)]
    public int Level { get; set; }
}
