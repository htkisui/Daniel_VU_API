using Entities;
using Services.Contracts.Requests.Pokemon;
using Services.Contracts.Responses.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface IPokemonService
{
    Task AddAsync(PokemonAddRequest pokemonAddRequest);
    Task<List<Pokemon>> GetAllAsync();
    Task<Pokemon?> GetByIdAsync(int id);
    Task<List<Pokemon>> GetByNameAsync(string name);
    Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest);
    Task<Pokemon?> DeleteAsync(int id);
}
