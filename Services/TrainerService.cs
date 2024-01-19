using Entities;
using Repository.Contracts;
using Service.Contracts;
using Service.Contracts.Mappers.Trainers;
using Service.Contracts.Requests.Trainers;
using Service.Contracts.Responses.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;
public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;
    private readonly ITrainerMapper _trainerMapper;

    public TrainerService(ITrainerRepository trainerRepository, ITrainerMapper trainerMapper)
    {
        _trainerRepository = trainerRepository;
        _trainerMapper = trainerMapper;
    }

    public async Task AddAsync(TrainerAddRequest trainerAddRequest)
    {
        var trainer = _trainerMapper.ToTrainer(trainerAddRequest);
        await _trainerRepository.AddAsync(trainer);
    }

    public async Task<TrainerFullResponse?> DeleteAsync(int id)
    {
        var trainer = await _trainerRepository.DeleteAsync(id);
        return _trainerMapper.ToTrainerFullResponse(trainer);
    }

    public async Task<List<TrainerFullResponse>> GetAllAsync()
    {
        var trainers =  await _trainerRepository.GetAllAsync();
        return trainers.Select(_trainerMapper.ToTrainerFullResponse).ToList();
    }

    public async Task<TrainerFullResponse?> GetByIdAsync(int id)
    {
        var trainer =  await _trainerRepository.GetByIdAsync(id);
        return _trainerMapper.ToTrainerFullResponse(trainer);
    }

    public async Task<List<TrainerFullResponse>> GetByNameAsync(string name)
    {
        var trainers =  await _trainerRepository.GetByNameAsync(name);
        return trainers.Select(_trainerMapper.ToTrainerFullResponse).ToList();
    }

    public async Task UpdateAsync(TrainerUpdateRequest trainerUpdateRequest)
    {
        var trainer = _trainerMapper.ToTrainer(trainerUpdateRequest);
        await _trainerRepository.UpdateAsync(trainer);
    }
}
