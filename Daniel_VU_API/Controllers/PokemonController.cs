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

    /// <summary>
    /// Get all pokemons.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<PokemonFullResponse>> GetAll()
    {
        var pokemonResponses = await _pokemonService.GetAllAsync();
        return Ok(pokemonResponses);
    }

    /// <summary>
    /// Get a pokemon by his Id.
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PokemonFullResponse>> GetById(int id)
    {
        try
        {
            var pokemonResponse = await _pokemonService.GetByIdAsync(id);
            return Ok(pokemonResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Get pokemons by their names.
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("Search/{name}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PokemonFullResponse>> Search(string name)
    {
        try
        {
            var pokemonResponse = await _pokemonService.GetByNameAsync(name);
            return Ok(pokemonResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Create a new pokemon.
    /// </summary>
    /// <param name="pokemonAddRequest"></param>
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Create(PokemonAddRequest pokemonAddRequest)
    {
        try
        {
            await _pokemonService.CreateAsync(pokemonAddRequest);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Update a pokemon.
    /// </summary>
    /// <param name="pokemonUpdateRequest"></param>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(PokemonUpdateRequest pokemonUpdateRequest)
    {
        try
        {
            await _pokemonService.UpdateAsync(pokemonUpdateRequest);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a pokemon.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PokemonFullResponse>> Delete(int id)
    {
        try
        {
            var pokemonResponse = await _pokemonService.DeleteAsync(id);
            return Ok(pokemonResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
