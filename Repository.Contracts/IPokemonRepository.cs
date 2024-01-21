using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts;
public interface IPokemonRepository
{
    /// <summary>
    /// Create a new pokemon.
    /// </summary>
    /// <param name="pokemon"></param>
    Task CreateAsync(Pokemon pokemon);

    /// <summary>
    /// Get all pokemons.
    /// </summary>
    /// <returns>A list of all pokemons.</returns>
    Task<List<Pokemon>> GetAllAsync();

    /// <summary>
    /// Get a pokemon by his Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The pokemon with this Id.</returns>
    Task<Pokemon> GetByIdAsync(int id);

    /// <summary>
    /// Get pokemons by their names.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A list of pokemon with this name.</returns>
    Task<List<Pokemon>> GetByNameAsync(string name);

    /// <summary>
    /// Update a pokemon.
    /// </summary>
    /// <param name="pokemon"></param>
    Task UpdateAsync(Pokemon pokemon);

    /// <summary>
    /// Delete a pokemon.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The pokemon deleted.</returns>
    Task<Pokemon> DeleteAsync(int id);
}
