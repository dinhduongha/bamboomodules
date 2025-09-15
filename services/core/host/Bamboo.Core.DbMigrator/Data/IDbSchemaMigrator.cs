using System.Threading.Tasks;

public interface IDbSchemaMigrator
{
    Task MigrateAsync();
}
