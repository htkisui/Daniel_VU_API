using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts;
public interface ITrainerRepository
{
    /// <summary>
    /// Create a new trainer.
    /// </summary>
    /// <param name="trainer"></param>
    Task CreateAsync(Trainer trainer);

    /// <summary>
    /// Get All trainers.
    /// </summary>
    /// <returns>A list of trainer.</returns>
    Task<List<Trainer>> GetAllAsync();

    /// <summary>
    /// Get a trainer by his Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The trainer with this Id.</returns>
    Task<Trainer> GetByIdAsync(int id);

    /// <summary>
    /// Get Trainers by their names.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A list of trainer with this name.</returns>
    Task<List<Trainer>> GetByNameAsync(string name);

    /// <summary>
    /// Update a trainer.
    /// </summary>
    /// <param name="trainer"></param>
    Task UpdateAsync(Trainer trainer);

    /// <summary>
    /// Delete a trainer.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The trainer deleted.</returns>
    Task<Trainer> DeleteAsync(int id);
}
