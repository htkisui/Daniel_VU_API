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
    Task AddAsync(TrainerAddRequest trainerAddRequest);
    Task<List<TrainerFullResponse>> GetAllAsync();
    Task<TrainerFullResponse?> GetByIdAsync(int id);
    Task<List<TrainerFullResponse>> GetByNameAsync(string name);
    Task UpdateAsync(TrainerUpdateRequest trainerUpdateRequest);
    Task<TrainerFullResponse?> DeleteAsync(int id);
}
