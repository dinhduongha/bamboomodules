using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Employee.MongoDB
{
    [ConnectionStringName(EmployeeDbProperties.ConnectionStringName)]
    public interface IEmployeeMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
