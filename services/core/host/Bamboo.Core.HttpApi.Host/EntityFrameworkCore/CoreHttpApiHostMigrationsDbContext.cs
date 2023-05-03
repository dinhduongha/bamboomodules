using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Core.EntityFrameworkCore;

public class CoreHttpApiHostMigrationsDbContext : AbpDbContext<CoreHttpApiHostMigrationsDbContext>
{
    public CoreHttpApiHostMigrationsDbContext(DbContextOptions<CoreHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCore();
    }
}
