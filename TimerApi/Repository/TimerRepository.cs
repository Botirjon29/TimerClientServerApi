using Microsoft.EntityFrameworkCore;
using TimerApi.Data;
using TimerApi.Entity;

namespace TimerApi.Repository;

public class TimerRepository : ITimerRepository
{
    private readonly AppDbContext _context;

    public TimerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TimerEntity> GetTimerByDateAsync(string startDate, string endDate)
    {
        var timer = await _context.Timers.FirstOrDefaultAsync(t => t.StartTime == startDate && t.EndTime == endDate);
        return timer;
    }

    public async Task CreateTimerAsync(TimerEntity timer)
    {
        await _context.Timers.AddAsync(timer);
        await _context.SaveChangesAsync();
    }
}