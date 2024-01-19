using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.Contracts.Requests.Pokemons;
using Service.Contracts.Responses.Pokemons;
using Service;
using Service.Contracts.Responses.Trainers;
using Service.Contracts.Requests.Trainers;

namespace Daniel_VU_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpGet]
    public async Task<ActionResult<TrainerFullResponse>> GetAll()
    {
        var trainerResponses = await _trainerService.GetAllAsync();
        return Ok(trainerResponses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainerFullResponse>> GetById(int id)
    {
        var trainerResponse = await _trainerService.GetByIdAsync(id);
        if (trainerResponse == null)
        {
            return NoContent();
        }
        return Ok(trainerResponse);
    }

    [HttpGet("Search/{name}")]
    public async Task<ActionResult<TrainerFullResponse>> Search(string name)
    {
        var trainerResponse = await _trainerService.GetByNameAsync(name);
        if (trainerResponse == null)
        {
            return NoContent();
        }
        return Ok(trainerResponse);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TrainerAddRequest trainerAddRequest)
    {
        await _trainerService.AddAsync(trainerAddRequest);
        return Ok("Dresseur ajouté");
    }

    [HttpPut]
    public async Task<ActionResult> Update(TrainerUpdateRequest trainerUpdateRequest)
    {
        await _trainerService.UpdateAsync(trainerUpdateRequest);
        return Ok("Dresseur modifié");
    }

    [HttpDelete]
    public async Task<ActionResult<TrainerFullResponse>> Delete(int id)
    {
        var trainerResponse = await _trainerService.DeleteAsync(id);
        if (trainerResponse == null)
        {
            return NoContent();
        }
        return Ok(trainerResponse);
    }
}
