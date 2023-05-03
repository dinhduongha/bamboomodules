using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Core.MongoDB;

[ConnectionStringName(CoreDbProperties.ConnectionStringName)]
public class CoreMongoDbContext : AbpMongoDbContext, ICoreMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCore();
    }
}
