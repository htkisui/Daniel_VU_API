using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.Contracts.Exceptions.Pokemons;
using Repository.Contracts.Exceptions.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class PokemonRepository : IPokemonRepository
{
    private readonly ApplicationDbContext _context;

    public PokemonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Pokemon pokemon)
    {
        var trainer = await _context.Trainers.FindAsync(pokemon.TrainerId);
        if (trainer == null)
        {
            throw new TrainerNotFoundException();
        }

        await _context.Pokemons.AddAsync(pokemon);
        await _context.SaveChangesAsync();
    }

    public async Task<Pokemon> DeleteAsync(int id)
    {
        var pokemon = await _context.Pokemons.FindAsync(id);
        if (pokemon == null)
        {
            throw new PokemonNotFoundException();
        }

        _context.Pokemons.Remove(pokemon);
        await _context.SaveChangesAsync();
        return pokemon;
    }

    public async Task<List<Pokemon>> GetAllAsync()
    {
        return await _context.Pokemons.Include(p => p.Trainer).ToListAsync();
    }

    public async Task<Pokemon> GetByIdAsync(int id)
    {
        var pokemon = await _context.Pokemons.Include(p => p.Trainer).FirstOrDefaultAsync(p => p.Id == id);
        if (pokemon == null)
        {
            throw new PokemonNotFoundException();
        }
        return pokemon;
    }

    public async Task<List<Pokemon>> GetByNameAsync(string name)
    {
        return await _context.Pokemons.Include(p => p.Trainer).Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToListAsync();
    }

    public async Task UpdateAsync(Pokemon pokemon)
    {
        var pokemonToUpdate = await _context.Pokemons.FindAsync(pokemon.Id);
        if (pokemonToUpdate == null)
        {
            throw new PokemonNotFoundException();
        }

        pokemonToUpdate.Name = pokemon.Name;
        pokemonToUpdate.Level = pokemon.Level;
        await _context.SaveChangesAsync();
    }
}
