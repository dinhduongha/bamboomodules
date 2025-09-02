using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICrmIapLeadMiningRequestAppService : IGenericApplicationService<CrmIapLeadMiningRequest>
    {
        Task<CrmIapLeadMiningRequest> BuyCreditsAsync(Guid id);
        Task<CrmIapLeadMiningRequest> DraftAsync(Guid id);
        Task<CrmIapLeadMiningRequest> GetEmptyListHelpAsync(Guid id, CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input);
        Task<CrmIapLeadMiningRequest> GetLeadActionAsync(Guid id);
        Task<CrmIapLeadMiningRequest> GetOpportunityActionAsync(Guid id);
        Task<CrmIapLeadMiningRequest> SubmitAsync(Guid id);
    }
}