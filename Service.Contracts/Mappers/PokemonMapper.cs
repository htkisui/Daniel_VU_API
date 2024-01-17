using Entities;
using Services.Contracts.Requests.Pokemon;
using Services.Contracts.Responses.Pokemon;
using Riok.Mapperly.Abstractions;

namespace Services.Contracts.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class PokemonMapper
{
    public partial Pokemon ToPokemon(PokemonAddRequest pokemonAddRequest);
    public partial Pokemon ToPokemon(PokemonUpdateRequest pokemonUpdateRequest);

    public partial PokemonResponse ToPokemonResponse(Pokemon pokemon);
}
