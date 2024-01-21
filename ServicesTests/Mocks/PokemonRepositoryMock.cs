using Entities;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests.Mocks;
public class PokemonRepositoryMock : IPokemonRepository
{
    public Task CreateAsync(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Pokemon>> GetAllAsync()
    {
        return new List<Pokemon>() { new Pokemon() };
    }

    public Task<Pokemon?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pokemon>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
