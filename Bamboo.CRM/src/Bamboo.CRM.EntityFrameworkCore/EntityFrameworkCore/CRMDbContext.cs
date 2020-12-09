using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.CRM.EntityFrameworkCore
{
    [ConnectionStringName(CRMDbProperties.ConnectionStringName)]
    public class CRMDbContext : AbpDbContext<CRMDbContext>, ICRMDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CRMDbContext(DbContextOptions<CRMDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCRM();
        }
    }
}