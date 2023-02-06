using Microsoft.EntityFrameworkCore;
using TimerApi.Entity;

namespace TimerApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<TimerEntity>? Timers { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }
}
