using Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;

namespace Daniel_VU_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult<PokemonFullResponse>> GetAll()
    {
        var pokemonResponses = await _pokemonService.GetAllAsync();
        return Ok(pokemonResponses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonFullResponse>> GetById(int id)
    {
        var pokemonResponse = await _pokemonService.GetByIdAsync(id);
        if (pokemonResponse == null)
        {
            return NoContent();
        }
        return Ok(pokemonResponse);
    }

    [HttpGet("Search/{name}")]
    public async Task<ActionResult<PokemonFullResponse>> Search(string name)
    {
        var pokemonResponse = await _pokemonService.GetByNameAsync(name);
        if (pokemonResponse == null)
        {
            return NoContent();
        }
        return Ok(pokemonResponse);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PokemonAddRequest pokemonAddRequest)
    {
        await _pokemonService.AddAsync(pokemonAddRequest);
        return Ok("Pokemon ajouté");
    }

    [HttpPut]
    public async Task<ActionResult> Update(PokemonUpdateRequest pokemonUpdateRequest)
    {
        await _pokemonService.UpdateAsync(pokemonUpdateRequest);
        return Ok("Pokemon modifié");
    }

    [HttpDelete]
    public async Task<ActionResult<PokemonFullResponse>> Delete(int id)
    {
        var pokemonResponse = await _pokemonService.DeleteAsync(id);
        if (pokemonResponse == null)
        {
            return NoContent();
        }
        return Ok(pokemonResponse);
    }
}
