using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests;

[TestClass()]
public class PokemonRepositoryTests
{
    [TestMethod()]
    public async Task UpdateAsyncTest()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("API");
        var context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        context.Pokemons.Add(new Pokemon() { Id = 1, Name = "Pokemon1", Level = 10 });
        context.Pokemons.Add(new Pokemon() { Id = 2, Name = "Pokemon2", Level = 40 });
        var pokemonRepository = new PokemonRepository(context);
        var resultExpected = 100;

        var pokemon = new Pokemon() { Id = 1, Name = "Pokemon1", Level = 100 };
        await pokemonRepository.UpdateAsync(pokemon);

        Assert.AreEqual(resultExpected, context.Pokemons.Find(1).Level);
    }
}