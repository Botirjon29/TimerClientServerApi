using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using TimerMudBlazor.Dto;
using TimerMudBlazor.ViewModel;

namespace TimerMudBlazor.Service;

public class TimerService : HttpClinetBase
{
    public TimerService(HttpClient httpClient) : base(httpClient){ }

    public async Task CreateTimerAsync(CreateTimerDto createTimerDto)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:5158/api/Timers");
        httpRequest.Content = JsonContent.Create(createTimerDto);

        httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        await httpClient.SendAsync(httpRequest);
    }
    
    public async Task<TimerView> GetTimerByDateAsync(string startDate, string endDate)
    {
        var httpRequest = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://localhost:5158/api/Timers?startDate={startDate}&endDate={endDate}");
        
        httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        var response = await httpClient.SendAsync(httpRequest);
        var productJson = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<TimerView>(productJson);
        }
        return new TimerView();
    }

}