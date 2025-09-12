using System.Threading.Tasks;

namespace Bamboo.Admin.Data;

public interface IAdminDbSchemaMigrator
{
    Task MigrateAsync();
}
