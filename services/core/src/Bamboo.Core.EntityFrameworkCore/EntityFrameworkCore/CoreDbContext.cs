using Microsoft.EntityFrameworkCore;
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

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseIdentityColumns();
        base.OnModelCreating(builder);

        builder.ConfigureCore();
        builder.ConfigureCoreFluentExt();
        builder.SnakeCase();
    }
}
