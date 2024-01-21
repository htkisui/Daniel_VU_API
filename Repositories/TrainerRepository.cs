using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.Contracts.Exceptions.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class TrainerRepository : ITrainerRepository
{
    private readonly ApplicationDbContext _context;

    public TrainerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Trainer trainer)
    {
        await _context.Trainers.AddAsync(trainer);
        await _context.SaveChangesAsync();
    }

    public async Task<Trainer> DeleteAsync(int id)
    {
        var trainer = await _context.Trainers.FindAsync(id);
        if (trainer == null)
        {
            throw new TrainerNotFoundException();
        }

        _context.Trainers.Remove(trainer);
        await _context.SaveChangesAsync();
        return trainer;
    }

    public async Task<List<Trainer>> GetAllAsync()
    {
        return await _context.Trainers.Include(t => t.Pokemons).ToListAsync();
    }

    public async Task<Trainer> GetByIdAsync(int id)
    {
        var trainer = await _context.Trainers.Include(t => t.Pokemons).FirstOrDefaultAsync(t => t.Id == id);
        if (trainer == null)
        {
            throw new TrainerNotFoundException();
        }

        return trainer;
    }

    public async Task<List<Trainer>> GetByNameAsync(string name)
    {
        return await _context.Trainers.Include(t => t.Pokemons).Where(t => EF.Functions.Like(t.Name, $"%{name}%")).ToListAsync();
    }

    public async Task UpdateAsync(Trainer trainer)
    {
        var trainerToUpdate = await _context.Trainers.FindAsync(trainer.Id);
        if (trainerToUpdate == null)
        {
            throw new TrainerNotFoundException();
        }

        trainerToUpdate.Name = trainer.Name;
        await _context.SaveChangesAsync();
    }
}
