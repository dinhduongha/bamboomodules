using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Employee.MongoDB
{
    [ConnectionStringName(EmployeeDbProperties.ConnectionStringName)]
    public class EmployeeMongoDbContext : AbpMongoDbContext, IEmployeeMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureEmployee();
        }
    }
}