using Entities;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task AddAsync(Pokemon pokemon)
    {
        await _pokemonRepository.AddAsync(pokemon);
    }

    public async Task<Pokemon?> DeleteAsync(int id)
    {
        return await _pokemonRepository.DeleteAsync(id);
    }

    public async Task<List<Pokemon>> GetAllAsync()
    {
        return await _pokemonRepository.GetAllAsync();
    }

    public async Task<Pokemon?> GetByIdAsync(int id)
    {
        return await _pokemonRepository.GetByIdAsync(id);
    }

    public async Task<Pokemon?> GetByNameAsync(string name)
    {
       return await _pokemonRepository.GetByNameAsync(name);
    }

    public async Task UpdateAsync(Pokemon pokemon)
    {
        await _pokemonRepository.UpdateAsync(pokemon);
    }
}
