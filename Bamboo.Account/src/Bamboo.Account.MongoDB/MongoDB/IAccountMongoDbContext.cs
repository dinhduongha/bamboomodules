using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Account.MongoDB
{
    [ConnectionStringName(AccountDbProperties.ConnectionStringName)]
    public interface IAccountMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
