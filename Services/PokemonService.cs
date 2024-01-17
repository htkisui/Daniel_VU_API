using Entities;
using Repository.Contracts;
using Service.Contracts;
using Services.Contracts.Mappers;
using Services.Contracts.Requests.Pokemon;
using Services.Contracts.Responses.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly PokemonMapper _pokemonMapper;

    public PokemonService(IPokemonRepository pokemonRepository, PokemonMapper pokemonMapper)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonMapper = pokemonMapper;
    }

    public async Task AddAsync(PokemonAddRequest pokemonAddRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonAddRequest);
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

    public async Task<List<Pokemon>> GetByNameAsync(string name)
    {
       return await _pokemonRepository.GetByNameAsync(name);
    }

    public async Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonUpdateRequest);
        await _pokemonRepository.UpdateAsync(pokemon);
    }
}
