using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts;
public interface IPokemonRepository
{
    Task AddAsync(Pokemon pokemon);
    Task<List<Pokemon>> GetAllAsync();
    Task<Pokemon?> GetByIdAsync(int id);
    Task<List<Pokemon>> GetByNameAsync(string name);
    Task UpdateAsync(Pokemon pokemon);
    Task<Pokemon?> DeleteAsync(int id);
}
