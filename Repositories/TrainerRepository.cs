using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class TrainerRepository : ITrainerRepository
{
    private readonly ApplicationContext _context;

    public TrainerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Trainer trainer)
    {
        await _context.Trainers.AddAsync(trainer);
        await _context.SaveChangesAsync();
    }

    public async Task<Trainer?> DeleteAsync(int id)
    {
        var trainer = _context.Trainers.FirstOrDefault(p => p.Id == id);
        if (trainer != null)
        {
            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();
        }
        return trainer;
    }

    public async Task<List<Trainer>> GetAllAsync()
    {
        return await _context.Trainers.Include(t => t.Pokemons).ToListAsync();
    }

    public async Task<Trainer?> GetByIdAsync(int id)
    {
        return await _context.Trainers.Include(t => t.Pokemons).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<Trainer>> GetByNameAsync(string name)
    {
        return await _context.Trainers.Include(t => t.Pokemons).Where(t => EF.Functions.Like(t.Name, $"%{name}%")).ToListAsync();
    }

    public async Task UpdateAsync(Trainer trainer)
    {
        var trainerToUpdate = _context.Trainers.FirstOrDefault(t => t.Id == trainer.Id);
        if (trainerToUpdate != null)
        {
            trainerToUpdate.Name = trainer.Name;
            await _context.SaveChangesAsync();
        }
    }
}
