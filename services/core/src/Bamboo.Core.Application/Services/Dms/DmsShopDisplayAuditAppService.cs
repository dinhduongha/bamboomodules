using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsShopDisplayAuditAppService : IGenericApplicationService<DmsShopDisplayAudit>
    {
        Task UpdateScoreAsync(Guid auditId, decimal score);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsShopDisplayAuditAppService : GenericApplicationService<DmsShopDisplayAudit>, IDmsShopDisplayAuditAppService
    {
        public DmsShopDisplayAuditAppService(
            IRepository<DmsShopDisplayAudit, Guid> repository,
            IServiceProvider serviceProvider,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IMemoryCache memoryCache)
            : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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