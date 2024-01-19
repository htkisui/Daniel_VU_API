using Entities;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using Riok.Mapperly.Abstractions;
using Service.Contracts.Mappers.Trainers;

namespace Service.Contracts.Mappers.Pokemons;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class PokemonMapper : IPokemonMapper
{

    public partial Pokemon ToPokemon(PokemonAddRequest pokemonAddRequest);
    public partial Pokemon ToPokemon(PokemonUpdateRequest pokemonUpdateRequest);

    private partial PokemonFullResponse CustomToPokemonFullResponse(Pokemon pokemon);
    public PokemonFullResponse ToPokemonFullResponse(Pokemon pokemon)
    {
        var trainerMapper = new TrainerMapper();
        var dto = CustomToPokemonFullResponse(pokemon);
        dto.Trainer = trainerMapper.ToTrainerSimpleResponse(pokemon.Trainer);
        return dto;
    }

    public partial PokemonSimpleResponse ToPokemonSimpleResponse(Pokemon pokemon);

}
