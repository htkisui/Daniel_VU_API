using Entities;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Mappers.Pokemons;
public interface IPokemonMapper
{
    Pokemon ToPokemon(PokemonAddRequest pokemonAddRequest);
    Pokemon ToPokemon(PokemonUpdateRequest pokemonUpdateRequest);
    PokemonFullResponse ToPokemonFullResponse(Pokemon pokemon);
    PokemonSimpleResponse ToPokemonSimpleResponse(Pokemon pokemon);
}
