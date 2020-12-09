using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Account.EntityFrameworkCore
{
    [ConnectionStringName(AccountDbProperties.ConnectionStringName)]
    public class AccountDbContext : AbpDbContext<AccountDbContext>, IAccountDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public AccountDbContext(DbContextOptions<AccountDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAccount();
        }
    }
}