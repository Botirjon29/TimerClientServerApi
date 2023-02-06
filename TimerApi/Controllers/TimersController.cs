using Microsoft.AspNetCore.Mvc;
using TimerApi.Data;
using TimerApi.Dto;
using TimerApi.Service;

namespace TimerApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TimersController : ControllerBase
{
    private readonly ITimerService _timerService;
    public TimersController(ITimerService timerService , AppDbContext context)
    {
        _timerService = timerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTimerAsync(CreateTimerDto timerDto)
    {
        await _timerService.CreateTimerAsync(timerDto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetTimerByDate(string startDate, string endDate)
    {
        var timer = await _timerService.GetTimerByDateAsync(startDate, endDate);
        return Ok(timer);
    }
}
