using TimerApi.Dto;
using TimerApi.Entity;
using TimerApi.Exceptions;
using TimerApi.ModelView;
using TimerApi.Repository;

namespace TimerApi.Service;

public class TimerService : ITimerService
{
    private readonly ITimerRepository _timerRepository;
    public TimerService(ITimerRepository timerRepository)
    {
        _timerRepository = timerRepository;
    }

    public async Task<TimerView> GetTimerByDateAsync(string startTime, string endTime)
    {
        var timer = await _timerRepository.GetTimerByDateAsync(startTime, endTime);
        if (timer is null) throw new NotFoundException<TimerEntity>();

        return new TimerView { StartTime = timer.StartTime, EndTime = timer.EndTime };
    }

    public async Task CreateTimerAsync(CreateTimerDto createTimerDto)
    {
        if (createTimerDto is null) throw new NotFoundException<TimerEntity>();
            
        var timer = new TimerEntity { StartTime = createTimerDto.StartTime, EndTime = createTimerDto.EndTime };
        await _timerRepository.CreateTimerAsync(timer);
    }
}