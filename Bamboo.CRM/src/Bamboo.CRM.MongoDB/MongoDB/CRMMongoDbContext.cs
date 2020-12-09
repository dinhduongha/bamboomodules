using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.CRM.MongoDB
{
    [ConnectionStringName(CRMDbProperties.ConnectionStringName)]
    public class CRMMongoDbContext : AbpMongoDbContext, ICRMMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCRM();
        }
    }
}