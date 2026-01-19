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
    public interface IDmsVMIProposalAppService : IGenericApplicationService<DmsVMIProposal>
    {
        Task GenerateProposalAsync(Guid partnerId);
        Task ApproveProposalAsync(Guid proposalId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class DmsVMIProposalAppService : GenericApplicationService<DmsVMIProposal>, IDmsVMIProposalAppService
    {
        public DmsVMIProposalAppService(
            IRepository<DmsVMIProposal, Guid> repository,
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

        public async Task GenerateProposalAsync(Guid partnerId)
        {
            // Logic generate proposal (placeholder)
        }

        public async Task ApproveProposalAsync(Guid proposalId)
        {
            var proposal = await Repository.GetAsync(proposalId);
            proposal.ApprovalStatus = "approved";
            await Repository.UpdateAsync(proposal);
        }
    }
}