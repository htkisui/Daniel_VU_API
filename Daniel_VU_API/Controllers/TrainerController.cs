using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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

    /// <summary>
    /// Get All trainers.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<TrainerFullResponse>> GetAll()
    {
        var trainerResponses = await _trainerService.GetAllAsync();
        return Ok(trainerResponses);
    }

    /// <summary>
    /// Get a trainer by his Id.
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TrainerFullResponse>> GetById(int id)
    {
        try
        {
            var trainerResponse = await _trainerService.GetByIdAsync(id);
            return Ok(trainerResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }

    /// <summary>
    /// Get Trainers by their names.
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("Search/{name}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TrainerFullResponse>> Search(string name)
    {
        try
        {
            var trainerResponse = await _trainerService.GetByNameAsync(name);
            return Ok(trainerResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Create a new trainer.
    /// </summary>
    /// <param name="trainerAddRequest"></param>
    [HttpPost]
    [ProducesResponseType(204)]
    public async Task<ActionResult> Create(TrainerAddRequest trainerAddRequest)
    {
        await _trainerService.CreateAsync(trainerAddRequest);
        return NoContent();
    }

    /// <summary>
    /// Update a trainer.
    /// </summary>
    /// <param name="trainerUpdateRequest"></param>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(TrainerUpdateRequest trainerUpdateRequest)
    {
        try
        {
            await _trainerService.UpdateAsync(trainerUpdateRequest);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a trainer.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TrainerFullResponse>> Delete(int id)
    {
        try
        {
            var trainerResponse = await _trainerService.DeleteAsync(id);
            return Ok(trainerResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
