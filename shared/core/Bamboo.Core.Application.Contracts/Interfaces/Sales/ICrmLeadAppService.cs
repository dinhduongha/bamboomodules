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
        Task<CrmLead> AssignGeoLocalizeAsync(Guid id, CrmLeadAssignGeoLocalizeRequestDto input);
        Task<CrmLead> AssignPartnerAsync(Guid id);
        Task<CrmLead> AssignPartnerAsync(Guid id, CrmLeadAssignPartnerRequestDto input);
        Task<CrmLead> AssignSalesmanOfAssignedPartnerAsync(Guid id);
        Task<CrmLead> ConvertOpportunityAsync(Guid id, CrmLeadConvertOpportunityRequestDto input);
        Task<CrmLead> CopyDataAsync(Guid id, CrmLeadCopyDataRequestDto input);
        Task<CrmLead> CreateOppPortalAsync(Guid id, CrmLeadCreateOppPortalRequestDto input);
        Task<CrmLead> GenerateLeadsAsync(Guid id);
        Task<CrmLead> GetEmptyListHelpAsync(Guid id, CrmLeadGetEmptyListHelpRequestDto input);
        Task<CrmLead> GetImportTemplatesAsync(Guid id);
        Task<CrmLead> GetRainbowmanMessageAsync(Guid id);
        Task<CrmLead> IapEnrichAsync(Guid id);
        Task<CrmLead> LogMeetingAsync(Guid id, CrmLeadLogMeetingRequestDto input);
        Task<CrmLead> MergeOpportunityAsync(Guid id, CrmLeadMergeOpportunityRequestDto input);
        Task<CrmLead> MessageNewAsync(Guid id, CrmLeadMessageNewRequestDto input);
        Task<CrmLead> NewQuotationAsync(Guid id);
        Task<CrmLead> OpenLivechatAsync(Guid id);
        Task<CrmLead> PartnerDesinterestedAsync(Guid id, CrmLeadPartnerDesinterestedRequestDto input);
        Task<CrmLead> PartnerInterestedAsync(Guid id, CrmLeadPartnerInterestedRequestDto input);
        Task<CrmLead> PreparePlsTooltipDataAsync(Guid id);
        Task<CrmLead> RedirectLeadOpportunityViewAsync(Guid id);
        Task<CrmLead> RedirectToLivechatSessionsAsync(Guid id);
        Task<CrmLead> RedirectToPageViewsAsync(Guid id);
        Task<CrmLead> RescheduleMeetingAsync(Guid id);
        Task<CrmLead> RestoreAsync(Guid id);
        Task<CrmLead> SaleQuotationsNewAsync(Guid id);
        Task<CrmLead> ScheduleMeetingAsync(Guid id, CrmLeadScheduleMeetingRequestDto input);
        Task<CrmLead> SearchFetchAsync(Guid id, CrmLeadSearchFetchRequestDto input);
        Task<CrmLead> SearchGeoPartnerAsync(Guid id);
        Task<CrmLead> SetAutomatedProbabilityAsync(Guid id);
        Task<CrmLead> SetLostAsync(Guid id);
        Task<CrmLead> SetWonAsync(Guid id);
        Task<CrmLead> SetWonRainbowmanAsync(Guid id);
        Task<CrmLead> ShowPotentialDuplicatesAsync(Guid id);
        Task<CrmLead> UnarchiveAsync(Guid id);
        Task<CrmLead> UpdateContactDetailsFromPortalAsync(Guid id, CrmLeadUpdateContactDetailsFromPortalRequestDto input);
        Task<CrmLead> UpdateLeadPortalAsync(Guid id, CrmLeadUpdateLeadPortalRequestDto input);
        Task<CrmLead> ViewSaleOrderAsync(Guid id);
        Task<CrmLead> ViewSaleQuotationAsync(Guid id);
        Task<CrmLead> WebsiteFormInputFilterAsync(Guid id, CrmLeadWebsiteFormInputFilterRequestDto input);
    }
}