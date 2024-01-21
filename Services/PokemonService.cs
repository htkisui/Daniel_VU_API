using Repository.Contracts;
using Repository.Contracts.Exceptions.Pokemons;
using Repository.Contracts.Exceptions.Trainers;
using Service.Contracts;
using Service.Contracts.Mappers.Pokemons;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;


namespace Services;
public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonMapper _pokemonMapper;

    public PokemonService(IPokemonRepository pokemonRepository, IPokemonMapper pokemonMapper)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonMapper = pokemonMapper;
    }

    public async Task CreateAsync(PokemonAddRequest pokemonAddRequest)
    {
        try
        {
            var pokemon = _pokemonMapper.ToPokemon(pokemonAddRequest);
            await _pokemonRepository.CreateAsync(pokemon);
        }
        catch (TrainerNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<PokemonFullResponse?> DeleteAsync(int id)
    {
        try
        {
            var pokemon = await _pokemonRepository.DeleteAsync(id);
            return _pokemonMapper.ToPokemonFullResponse(pokemon);
        }
        catch (PokemonNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<PokemonFullResponse>> GetAllAsync()
    {
        var pokemons = await _pokemonRepository.GetAllAsync();
        return pokemons.Select(_pokemonMapper.ToPokemonFullResponse).ToList();
    }

    public async Task<PokemonFullResponse?> GetByIdAsync(int id)
    {
        try
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            return _pokemonMapper.ToPokemonFullResponse(pokemon);
        }
        catch (PokemonNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<PokemonFullResponse>> GetByNameAsync(string name)
    {
        try
        {
            var pokemons = await _pokemonRepository.GetByNameAsync(name);
            return pokemons.Select(_pokemonMapper.ToPokemonFullResponse).ToList();
        }
        catch (PokemonNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateAsync(PokemonUpdateRequest pokemonUpdateRequest)
    {
        try
        {
            var pokemon = _pokemonMapper.ToPokemon(pokemonUpdateRequest);
            await _pokemonRepository.UpdateAsync(pokemon);
        }
        catch (PokemonNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }
}
