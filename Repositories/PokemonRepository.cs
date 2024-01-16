using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class PokemonRepository : IPokemonRepository
{
    private readonly ApplicationContext _context;

    public PokemonRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Pokemon pokemon)
    {
        await _context.Pokemons.AddAsync(pokemon);
        await _context.SaveChangesAsync();
    }

    public async Task<Pokemon?> DeleteAsync(int id)
    {
        var pokemon = _context.Pokemons.FirstOrDefault(p => p.Id == id);
        if (pokemon != null)
        {
            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
        }
        return pokemon;
    }

    public async Task<List<Pokemon>> GetAllAsync()
    {
        return await _context.Pokemons.ToListAsync();
    }

    public async Task<Pokemon?> GetByIdAsync(int id)
    {
        return await _context.Pokemons.FindAsync(id);
    }

    public async Task<Pokemon?> GetByNameAsync(string name)
    {
        return await _context.Pokemons.FirstOrDefaultAsync(p => EF.Functions.Like(p.Name, $"%{name}%"));
    }

    public async Task UpdateAsync(Pokemon pokemon)
    {
        var pokemonToUpdate = _context.Pokemons.FirstOrDefault(p => p.Id == pokemon.Id);
        if (pokemonToUpdate != null)
        {
            pokemonToUpdate.Name = pokemon.Name;
            pokemonToUpdate.Level = pokemon.Level;
            await _context.SaveChangesAsync();
        }
    }
}
