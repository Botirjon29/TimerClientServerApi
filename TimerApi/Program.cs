using TimerApi.Data;
using TimerApi.Repository;
using TimerApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITimerService,TimerService>();
builder.Services.AddScoped<ITimerRepository, TimerRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("localhost"));
});

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:5001","http://localhost:5000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();