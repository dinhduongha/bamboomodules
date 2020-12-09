using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.CRM.EntityFrameworkCore
{
    [ConnectionStringName(CRMDbProperties.ConnectionStringName)]
    public interface ICRMDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}