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
    public interface IDmsTargetAssignmentAppService : IGenericAppService<DmsTargetAssignment>
    {
        Task AssignTargetAsync(Guid userId, string period, decimal salesTarget, int visitTarget);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsTargetAssignmentAppService : GenericAppService<DmsTargetAssignment>, IDmsTargetAssignmentAppService
    {
        public DmsTargetAssignmentAppService(
            IRepository<DmsTargetAssignment, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task AssignTargetAsync(Guid userId, string period, decimal salesTarget, int visitTarget)
        {
            var target = new DmsTargetAssignment
            {
                UserId = userId,
                Period = period,
                TargetSalesAmount = salesTarget,
                TargetVisitCount = visitTarget
            };
            await Repository.InsertAsync(target);
        }
    }
}