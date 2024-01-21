using Entities;
using Service.Contracts.Requests.Trainers;
using Service.Contracts.Responses.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface ITrainerService
{
    /// <summary>
    /// Create a new trainer.
    /// </summary>
    /// <param name="trainerAddRequest"></param>
    Task CreateAsync(TrainerAddRequest trainerAddRequest);

    /// <summary>
    /// Get All trainers.
    /// </summary>
    /// <returns>A list of trainer.</returns>
    Task<List<TrainerFullResponse>> GetAllAsync();

    /// <summary>
    /// Get a trainer by his Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The trainer with this Id.</returns>
    Task<TrainerFullResponse?> GetByIdAsync(int id);

    /// <summary>
    /// Get Trainers by their names.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A list of trainer with this name.</returns>
    Task<List<TrainerFullResponse>> GetByNameAsync(string name);

    /// <summary>
    /// Update a trainer.
    /// </summary>
    /// <param name="trainerUpdateRequest"></param>
    Task UpdateAsync(TrainerUpdateRequest trainerUpdateRequest);

    /// <summary>
    /// Delete a trainer.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The trainer deleted.</returns>
    Task<TrainerFullResponse?> DeleteAsync(int id);
}
