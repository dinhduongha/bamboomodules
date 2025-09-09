using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IUtmCampaignAppService : IGenericApplicationService<UtmCampaign>
    {
        Task<UtmCampaign> CreateMassSmsAsync(Guid id);
        Task<UtmCampaign> RedirectToInvoicedAsync(Guid id);
        Task<UtmCampaign> RedirectToLeadsOpportunitiesAsync(Guid id);
        Task<UtmCampaign> RedirectToMailingSmsAsync(Guid id);
        Task<UtmCampaign> RedirectToQuotationsAsync(Guid id);
    }
}