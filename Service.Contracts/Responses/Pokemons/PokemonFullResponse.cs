using Service.Contracts.Responses.Trainers;

namespace Service.Contracts.Responses.Pokemons;

public class PokemonFullResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }

    public int TrainerId { get; set; }
    public TrainerSimpleResponse Trainer { get; set; }
}
