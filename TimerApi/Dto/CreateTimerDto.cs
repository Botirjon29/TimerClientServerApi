using Microsoft.Build.Framework;

namespace TimerApi.Dto;

public class CreateTimerDto
{
    [Required]
    public string? StartTime { get; set; }
    [Required]
    public string? EndTime { get; set; }
    
}