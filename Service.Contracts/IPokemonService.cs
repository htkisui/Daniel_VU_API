using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface IPokemonService
{
    Task AddAsync(Pokemon pokemon);
    Task<List<Pokemon>> GetAllAsync();
    Task<Pokemon?> GetByIdAsync(int id);
    Task<Pokemon?> GetByNameAsync(string name);
    Task UpdateAsync(Pokemon pokemon);
    Task<Pokemon?> DeleteAsync(int id);
}
