using Repository.Contracts;
using Repository.Contracts.Exceptions.Trainers;
using Service.Contracts;
using Service.Contracts.Mappers.Trainers;
using Service.Contracts.Requests.Trainers;
using Service.Contracts.Responses.Trainers;

namespace Services;
public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;
    private readonly ITrainerMapper _trainerMapper;

    public TrainerService(ITrainerRepository trainerRepository, ITrainerMapper trainerMapper)
    {
        _trainerRepository = trainerRepository;
        _trainerMapper = trainerMapper;
    }

    public async Task CreateAsync(TrainerAddRequest trainerAddRequest)
    {
        var trainer = _trainerMapper.ToTrainer(trainerAddRequest);
        await _trainerRepository.CreateAsync(trainer);
    }

    public async Task<TrainerFullResponse?> DeleteAsync(int id)
    {
        try
        {
            var trainer = await _trainerRepository.DeleteAsync(id);
            return _trainerMapper.ToTrainerFullResponse(trainer);
        }
        catch (TrainerNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<TrainerFullResponse>> GetAllAsync()
    {
        var trainers = await _trainerRepository.GetAllAsync();
        return trainers.Select(_trainerMapper.ToTrainerFullResponse).ToList();
    }

    public async Task<TrainerFullResponse?> GetByIdAsync(int id)
    {
        try
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            return _trainerMapper.ToTrainerFullResponse(trainer);
        }
        catch (TrainerNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<TrainerFullResponse>> GetByNameAsync(string name)
    {
        var trainers = await _trainerRepository.GetByNameAsync(name);
        return trainers.Select(_trainerMapper.ToTrainerFullResponse).ToList();
    }

    public async Task UpdateAsync(TrainerUpdateRequest trainerUpdateRequest)
    {
        try
        {
            var trainer = _trainerMapper.ToTrainer(trainerUpdateRequest);
            await _trainerRepository.UpdateAsync(trainer);
        }
        catch (TrainerNotFoundException e)
        {
            throw new Exception(e.Message);
        }
    }
}
