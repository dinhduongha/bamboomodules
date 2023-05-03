using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Core.MongoDB;

[ConnectionStringName(CoreDbProperties.ConnectionStringName)]
public interface ICoreMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
