using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.CRM.MongoDB
{
    [ConnectionStringName(CRMDbProperties.ConnectionStringName)]
    public interface ICRMMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
