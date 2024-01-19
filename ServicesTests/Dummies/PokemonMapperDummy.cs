using Entities;
using Service.Contracts.Mappers.Pokemons;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests.Dummies;
public class PokemonMapperDummy : IPokemonMapper
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
        throw new NotImplementedException();
    }

    public PokemonSimpleResponse ToPokemonSimpleResponse(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
