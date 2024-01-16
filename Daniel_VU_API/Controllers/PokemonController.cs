using Daniel_VU_API.Dto.Pokemon;
using Daniel_VU_API.Mappers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Daniel_VU_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;
    private readonly PokemonMapper _pokemonMapper;

    public PokemonController(IPokemonService pokemonService, PokemonMapper pokemonMapper)
    {
        _pokemonService = pokemonService;
        _pokemonMapper = pokemonMapper;
    }

    [HttpGet]
    public async Task<ActionResult<Pokemon>> GetAll()
    {
        var pokemons = await _pokemonService.GetAllAsync();
        var pokemonResponses = pokemons.Select(_pokemonMapper.ToPokemonResponse);
        return Ok(pokemonResponses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> GetById(int id)
    {
        var pokemon = await _pokemonService.GetByIdAsync(id);
        if (pokemon == null)
        {
            return NoContent();
        }
        var pokemonResponse = _pokemonMapper.ToPokemonResponse(pokemon);
        return Ok(pokemonResponse);
    }

    [HttpGet("Search/{name}")]
    public async Task<ActionResult<Pokemon>> Search(string name)
    {
        var pokemon = await _pokemonService.GetByNameAsync(name);
        if (pokemon == null)
        {
            return NoContent();
        }
        var pokemonResponse = _pokemonMapper.ToPokemonResponse(pokemon);
        return Ok(pokemonResponse);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PokemonAddRequest pokemonAddRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonAddRequest);
        await _pokemonService.AddAsync(pokemon);
        if (pokemon == null)
        {
            return NoContent();
        }
        return Ok("Pokemon ajouté");
    }

    [HttpPut]
    public async Task<ActionResult> Update(PokemonUpdateRequest pokemonUpdateRequest)
    {
        var pokemon = _pokemonMapper.ToPokemon(pokemonUpdateRequest);
        await _pokemonService.UpdateAsync(pokemon);
        if (pokemon == null)
        {
            return NoContent();
        }
        return Ok("Pokemon modifié");
    }

    [HttpDelete]
    public async Task<ActionResult<Pokemon>> Delete(int id)
    {
        var pokemon = await _pokemonService.DeleteAsync(id);
        if (pokemon == null)
        {
            return NoContent();
        }
        var pokemonResponse = _pokemonMapper.ToPokemonResponse(pokemon);
        return Ok(pokemonResponse);
    }
}
