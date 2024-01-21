using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests;

[TestClass()]
public class PokemonServiceTests
{
    [TestMethod()]
    public async Task GetAllAsyncTest()
    {
        var pokemonMapper = new PokemonMapperMock();
        var pokemonRepository = new PokemonRepositoryMock();
        var pokemonService = new PokemonService(pokemonRepository, pokemonMapper);
        var resultExpected = 1;

        var pokemons = await pokemonService.GetAllAsync();

        Assert.AreEqual(resultExpected, pokemons.Count);
    }
}