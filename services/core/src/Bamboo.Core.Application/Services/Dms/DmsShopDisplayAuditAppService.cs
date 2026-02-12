using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsShopDisplayAuditAppService : IGenericAppService<DmsShopDisplayAudit>
    {
        Task UpdateScoreAsync(Guid auditId, decimal score);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsShopDisplayAuditAppService : GenericAppService<DmsShopDisplayAudit>, IDmsShopDisplayAuditAppService
    {
        public DmsShopDisplayAuditAppService(
            IRepository<DmsShopDisplayAudit, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task UpdateScoreAsync(Guid auditId, decimal score)
        {
            var audit = await Repository.GetAsync(auditId);
            audit.DisplayScore = score;
            await Repository.UpdateAsync(audit);
        }
    }
}