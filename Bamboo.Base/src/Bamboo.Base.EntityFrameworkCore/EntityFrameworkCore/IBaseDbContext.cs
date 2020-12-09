using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Base.EntityFrameworkCore
{
    [ConnectionStringName(BaseDbProperties.ConnectionStringName)]
    public interface IBaseDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}