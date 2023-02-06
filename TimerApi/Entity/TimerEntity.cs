using Microsoft.Build.Framework;

namespace TimerApi.Entity;

public class TimerEntity
{
    public int Id { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
}