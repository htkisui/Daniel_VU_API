using Service.Contracts.Responses.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Responses.Trainers;
public class TrainerFullResponse
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public List<PokemonSimpleResponse> Pokemons { get; set; } = [];
}
