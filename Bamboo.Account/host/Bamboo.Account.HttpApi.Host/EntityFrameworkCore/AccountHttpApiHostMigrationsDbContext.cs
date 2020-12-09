using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Account.EntityFrameworkCore
{
    public class AccountHttpApiHostMigrationsDbContext : AbpDbContext<AccountHttpApiHostMigrationsDbContext>
    {
        public AccountHttpApiHostMigrationsDbContext(DbContextOptions<AccountHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAccount();
        }
    }
}
