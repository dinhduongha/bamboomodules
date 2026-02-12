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
    public interface IDmsSalesKPIAppService : IGenericAppService<DmsSalesKPI>
    {
        Task UpdateKPIAsync(Guid kpiId, decimal actualValue);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsSalesKPIAppService : GenericAppService<DmsSalesKPI>, IDmsSalesKPIAppService
    {
        public DmsSalesKPIAppService(
            IRepository<DmsSalesKPI, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task UpdateKPIAsync(Guid kpiId, decimal actualValue)
        {
            var kpi = await Repository.GetAsync(kpiId);
            kpi.ActualValue = actualValue;
            kpi.Score = kpi.TargetValue > 0 ? actualValue / kpi.TargetValue * 100 : 0;
            await Repository.UpdateAsync(kpi);
        }
    }
}