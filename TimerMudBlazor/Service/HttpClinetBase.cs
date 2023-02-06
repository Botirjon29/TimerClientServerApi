namespace TimerMudBlazor.Service;

public class HttpClinetBase
{
    protected HttpClient httpClient;

    public HttpClinetBase(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
}