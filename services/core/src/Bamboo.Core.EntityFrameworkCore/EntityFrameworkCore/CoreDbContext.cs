using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Core.EntityFrameworkCore;

[ConnectionStringName(CoreDbProperties.ConnectionStringName)]
public partial class CoreDbContext : AbpDbContext<CoreDbContext>, ICoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Debug);
        optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseIdentityColumns();
        base.OnModelCreating(builder);

        builder.ConfigureCore();
        //builder.ConfigureCoreFluentExt();
        builder.ApplyAllConfigurations();
        builder.SnakeCase();
    }
}
