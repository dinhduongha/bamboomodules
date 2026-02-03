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
    public interface IUtmCampaignAppService : IGenericAppService<UtmCampaign>
    {
        Task<UtmCampaign> CreateMassSmsAsync(Guid[] ids);
        Task<UtmCampaign> RedirectToInvoicedAsync(Guid[] ids);
        Task<UtmCampaign> RedirectToLeadsOpportunitiesAsync(Guid[] ids);
        Task<UtmCampaign> RedirectToMailingSmsAsync(Guid[] ids);
        Task<UtmCampaign> RedirectToQuotationsAsync(Guid[] ids);
    }
}