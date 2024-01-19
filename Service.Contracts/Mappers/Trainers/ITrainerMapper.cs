using Entities;
using Service.Contracts.Requests.Trainers;
using Service.Contracts.Responses.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Mappers.Trainers;
public interface ITrainerMapper
{
    Trainer ToTrainer(TrainerAddRequest trainerAddRequest);
    Trainer ToTrainer(TrainerUpdateRequest trainerUpdateRequest);
    TrainerFullResponse ToTrainerFullResponse(Trainer trainer);
    TrainerSimpleResponse ToTrainerSimpleResponse(Trainer trainer);
}
