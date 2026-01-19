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
    public interface IDmsTargetAssignmentAppService : IGenericApplicationService<DmsTargetAssignment>
    {
        Task AssignTargetAsync(Guid userId, string period, decimal salesTarget, int visitTarget);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsTargetAssignmentAppService : GenericApplicationService<DmsTargetAssignment>, IDmsTargetAssignmentAppService
    {
        public DmsTargetAssignmentAppService(
            IRepository<DmsTargetAssignment, Guid> repository,
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