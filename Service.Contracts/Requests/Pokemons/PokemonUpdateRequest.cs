using System.ComponentModel.DataAnnotations;

namespace Service.Contracts.Responses.Pokemons;

public class PokemonUpdateRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Range(0, 100)]
    public int Level { get; set; }

}
