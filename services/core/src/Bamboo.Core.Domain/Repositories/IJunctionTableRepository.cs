using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.Domain.Repositories;
public interface IJunctionTableRepository : ITransientDependency
{
    Task InsertJunctionRecordsAsync(string tableName, string leftKey, Guid leftId, string rightKey, List<Guid> rightIds, Guid? tenantId);
}