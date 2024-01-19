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
    Task AddAsync(PokemonAddRequest pokemonAddRequest);
    Task<List<PokemonFullResponse>> GetAllAsync();
    Task<PokemonFullResponse?> GetByIdAsync(int id);
    Task<List<PokemonFullResponse>> GetByNameAsync(string name);
    Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest);
    Task<PokemonFullResponse?> DeleteAsync(int id);
}
