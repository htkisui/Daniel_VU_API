using Daniel_VU_API.Dto.Pokemon;
using Entities;
using Riok.Mapperly.Abstractions;

namespace Daniel_VU_API.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class PokemonMapper
{
    public partial Pokemon ToPokemon(PokemonAddRequest pokemonAddRequest);
    public partial Pokemon ToPokemon(PokemonUpdateRequest pokemonUpdateRequest);

    public partial PokemonResponse ToPokemonResponse(Pokemon pokemon);
}
