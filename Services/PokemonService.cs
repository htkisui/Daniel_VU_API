using Entities;
using Repository.Contracts;
using Service.Contracts;
using Service.Contracts.Mappers.Pokemons;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;
public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonMapper _pokemonMapper;

    public PokemonService(IPokemonRepository pokemonRepository, IPokemonMapper pokemonMapper)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonMapper = pokemonMapper;
    }

    public async Task AddAsync(PokemonAddRequest pokemonAddRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonAddRequest);
        await _pokemonRepository.AddAsync(pokemon);
    }

    public async Task<PokemonFullResponse?> DeleteAsync(int id)
    {
        var pokemon = await _pokemonRepository.DeleteAsync(id);
        return _pokemonMapper.ToPokemonFullResponse(pokemon);
    }

    public async Task<List<PokemonFullResponse>> GetAllAsync()
    {
        var pokemons = await _pokemonRepository.GetAllAsync();
        return pokemons.Select(_pokemonMapper.ToPokemonFullResponse).ToList();
    }

    public async Task<PokemonFullResponse?> GetByIdAsync(int id)
    {
        var pokemon = await _pokemonRepository.GetByIdAsync(id);
        return _pokemonMapper.ToPokemonFullResponse(pokemon);
    }

    public async Task<List<PokemonFullResponse>> GetByNameAsync(string name)
    {
        var pokemons = await _pokemonRepository.GetByNameAsync(name);
        return pokemons.Select(_pokemonMapper.ToPokemonFullResponse).ToList();
    }

    public async Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonUpdateRequest);
        await _pokemonRepository.UpdateAsync(pokemon);
    }
}
