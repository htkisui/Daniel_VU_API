using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts;
public interface ITrainerRepository
{
    Task AddAsync(Trainer trainer);
    Task<List<Trainer>> GetAllAsync();
    Task<Trainer?> GetByIdAsync(int id);
    Task<List<Trainer>> GetByNameAsync(string name);
    Task UpdateAsync(Trainer trainer);
    Task<Trainer?> DeleteAsync(int id);
}
