using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bamboo.Core.Application;
public interface IJunctionTableService : IApplicationService
{
    Task<bool> IsMany2ManyRelationAsync(string model, string fieldName);
    Task InsertJunctionRecordsAsync(string model, string fieldName, Guid recordId, List<Guid> relatedIds, Guid? tenantId);
}