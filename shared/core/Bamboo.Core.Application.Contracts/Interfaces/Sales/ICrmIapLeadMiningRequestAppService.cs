using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICrmIapLeadMiningRequestAppService : IGenericAppService<CrmIapLeadMiningRequest>
    {
        Task<CrmIapLeadMiningRequest> BuyCreditsAsync(Guid[] ids);
        Task<CrmIapLeadMiningRequest> DraftAsync(Guid[] ids);
        Task<CrmIapLeadMiningRequest> GetEmptyListHelpAsync(CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input);
        Task<CrmIapLeadMiningRequest> GetLeadActionAsync(Guid[] ids);
        Task<CrmIapLeadMiningRequest> GetOpportunityActionAsync(Guid[] ids);
        Task<CrmIapLeadMiningRequest> SubmitAsync(Guid[] ids);
    }
}