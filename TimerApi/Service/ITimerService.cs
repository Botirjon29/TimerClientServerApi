using TimerApi.Dto;
using TimerApi.ModelView;

namespace TimerApi.Service;

public interface ITimerService
{
    Task<TimerView> GetTimerByDateAsync(string startTime, string endTime);
    Task CreateTimerAsync(CreateTimerDto createTimerDto);
}