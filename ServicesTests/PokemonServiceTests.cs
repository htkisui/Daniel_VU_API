using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using ServicesTests.Dummies;
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
    public async void GetAllAsyncTest()
    {
        Assert.Fail();
        var pokemonMapper = new PokemonMapperDummy();
        var pokemonRepository = new PokemonRepositoryMock();
        var pokemonService = new PokemonService(pokemonRepository, pokemonMapper);
        var resultExpected = 1;

        var pokemons = await pokemonService.GetAllAsync();
        Assert.AreEqual(resultExpected, pokemons.Count());
    }
}