using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Account.MongoDB
{
    [ConnectionStringName(AccountDbProperties.ConnectionStringName)]
    public class AccountMongoDbContext : AbpMongoDbContext, IAccountMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAccount();
        }
    }
}