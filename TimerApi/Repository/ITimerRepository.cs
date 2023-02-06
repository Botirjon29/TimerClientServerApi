using TimerApi.Dto;
using TimerApi.ModelView;
using TimerApi.Entity;

namespace TimerApi.Repository;

public interface ITimerRepository
{
    Task<TimerEntity> GetTimerByDateAsync(string startDate, string endDate);
    Task CreateTimerAsync(TimerEntity timer);
}