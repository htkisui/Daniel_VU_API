using Entities;
using Service.Contracts.Mappers.Pokemons;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests.Mocks;
public class PokemonMapperMock : IPokemonMapper
{
    public Pokemon ToPokemon(PokemonAddRequest pokemonAddRequest)
    {
        throw new NotImplementedException();
    }

    public Pokemon ToPokemon(PokemonUpdateRequest pokemonUpdateRequest)
    {
        throw new NotImplementedException();
    }

    public PokemonFullResponse ToPokemonFullResponse(Pokemon pokemon)
    {
        return new PokemonFullResponse();
    }

    public PokemonSimpleResponse ToPokemonSimpleResponse(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
