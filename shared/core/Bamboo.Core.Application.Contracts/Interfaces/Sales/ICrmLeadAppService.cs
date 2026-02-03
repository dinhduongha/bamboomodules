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
    public interface ICrmLeadAppService : IGenericApplicationService<CrmLead>
    {
        Task<CrmLead> AssignGeoLocalizeAsync(CrmLeadAssignGeoLocalizeRequestDto input);
        Task<CrmLead> AssignPartnerAsync(Guid[] ids);
        Task<CrmLead> AssignPartnerAsync(CrmLeadAssignPartnerRequestDto input);
        Task<CrmLead> AssignSalesmanOfAssignedPartnerAsync(Guid[] ids);
        Task<CrmLead> ConvertOpportunityAsync(CrmLeadConvertOpportunityRequestDto input);
        Task<CrmLead> CopyDataAsync(CrmLeadCopyDataRequestDto input);
        Task<CrmLead> CreateOppPortalAsync(CrmLeadCreateOppPortalRequestDto input);
        Task<CrmLead> GenerateLeadsAsync(Guid[] ids);
        Task<CrmLead> GetEmptyListHelpAsync(CrmLeadGetEmptyListHelpRequestDto input);
        Task<CrmLead> GetImportTemplatesAsync(Guid[] ids);
        Task<CrmLead> GetRainbowmanMessageAsync(Guid[] ids);
        Task<CrmLead> IapEnrichAsync(Guid[] ids);
        Task<CrmLead> LogMeetingAsync(CrmLeadLogMeetingRequestDto input);
        Task<CrmLead> MergeOpportunityAsync(CrmLeadMergeOpportunityRequestDto input);
        Task<CrmLead> MessageNewAsync(CrmLeadMessageNewRequestDto input);
        Task<CrmLead> NewQuotationAsync(Guid[] ids);
        Task<CrmLead> OpenLivechatAsync(Guid[] ids);
        Task<CrmLead> PartnerDesinterestedAsync(CrmLeadPartnerDesinterestedRequestDto input);
        Task<CrmLead> PartnerInterestedAsync(CrmLeadPartnerInterestedRequestDto input);
        Task<CrmLead> PreparePlsTooltipDataAsync(Guid[] ids);
        Task<CrmLead> RedirectLeadOpportunityViewAsync(Guid[] ids);
        Task<CrmLead> RedirectToLivechatSessionsAsync(Guid[] ids);
        Task<CrmLead> RedirectToPageViewsAsync(Guid[] ids);
        Task<CrmLead> RescheduleMeetingAsync(Guid[] ids);
        Task<CrmLead> RestoreAsync(Guid[] ids);
        Task<CrmLead> SaleQuotationsNewAsync(Guid[] ids);
        Task<CrmLead> ScheduleMeetingAsync(CrmLeadScheduleMeetingRequestDto input);
        Task<CrmLead> SearchFetchAsync(CrmLeadSearchFetchRequestDto input);
        Task<CrmLead> SearchGeoPartnerAsync(Guid[] ids);
        Task<CrmLead> SetAutomatedProbabilityAsync(Guid[] ids);
        Task<CrmLead> SetLostAsync(Guid[] ids);
        Task<CrmLead> SetWonAsync(Guid[] ids);
        Task<CrmLead> SetWonRainbowmanAsync(Guid[] ids);
        Task<CrmLead> ShowPotentialDuplicatesAsync(Guid[] ids);
        Task<CrmLead> UnarchiveAsync(Guid[] ids);
        Task<CrmLead> UpdateContactDetailsFromPortalAsync(CrmLeadUpdateContactDetailsFromPortalRequestDto input);
        Task<CrmLead> UpdateLeadPortalAsync(CrmLeadUpdateLeadPortalRequestDto input);
        Task<CrmLead> ViewSaleOrderAsync(Guid[] ids);
        Task<CrmLead> ViewSaleQuotationAsync(Guid[] ids);
        Task<CrmLead> WebsiteFormInputFilterAsync(CrmLeadWebsiteFormInputFilterRequestDto input);
    }
}