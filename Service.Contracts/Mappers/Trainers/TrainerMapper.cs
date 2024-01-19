using Entities;
using Riok.Mapperly.Abstractions;
using Service.Contracts.Mappers.Pokemons;
using Service.Contracts.Requests.Trainers;
using Service.Contracts.Responses.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Mappers.Trainers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class TrainerMapper : ITrainerMapper
{

    public partial Trainer ToTrainer(TrainerAddRequest trainerAddRequest);
    public partial Trainer ToTrainer(TrainerUpdateRequest trainerUpdateRequest);
    private partial TrainerFullResponse CustomToTrainerFullResponse(Trainer trainer);
    public TrainerFullResponse ToTrainerFullResponse(Trainer trainer)
    {
        var pokemonMapper = new PokemonMapper();
        var dto = CustomToTrainerFullResponse(trainer);
        dto.Pokemons = trainer.Pokemons.Select(pokemonMapper.ToPokemonSimpleResponse).ToList();
        return dto;
    }

    public partial TrainerSimpleResponse ToTrainerSimpleResponse(Trainer trainer);
}
