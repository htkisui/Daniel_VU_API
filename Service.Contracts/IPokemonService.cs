using Entities;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface IPokemonService
{
    /// <summary>
    /// Create a new pokemon.
    /// </summary>
    /// <param name="pokemonAddRequest"></param>
    /// <returns></returns>
    Task CreateAsync(PokemonAddRequest pokemonAddRequest);

    /// <summary>
    /// Get all pokemons.
    /// </summary>
    /// <returns>A list of all pokemons.</returns>
    Task<List<PokemonFullResponse>> GetAllAsync();

    /// <summary>
    /// Get a pokemon by his Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The pokemon with this Id.</returns>
    Task<PokemonFullResponse?> GetByIdAsync(int id);

    /// <summary>
    /// Get pokemons by their names.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A list of pokemon with this name.</returns>
    Task<List<PokemonFullResponse>> GetByNameAsync(string name);

    /// <summary>
    /// Update a pokemon.
    /// </summary>
    /// <param name="pokemonUpdateRequest"></param>
    Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest);

    /// <summary>
    /// Delete a pokemon.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The pokemon deleted.</returns>
    Task<PokemonFullResponse?> DeleteAsync(int id);
}
