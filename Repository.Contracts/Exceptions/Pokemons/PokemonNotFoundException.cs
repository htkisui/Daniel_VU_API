using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Exceptions.Pokemons;
public class PokemonNotFoundException : Exception
{
    public override string Message => "Le pokemon n'existe pas";
}
