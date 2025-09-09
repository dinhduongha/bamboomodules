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
    public interface IWebsiteAppService : IGenericApplicationService<Website>
    {
        Task<Website> ButtonGoWebsiteAsync(Guid id, WebsiteButtonGoWebsiteRequestDto input);
        Task<Website> ConfiguratorApplyAsync(Guid id);
        Task<Website> ConfiguratorGetFooterLinksAsync(Guid id);
        Task<Website> ConfiguratorInitAsync(Guid id);
        Task<Website> ConfiguratorMissingIndustryAsync(Guid id, WebsiteConfiguratorMissingIndustryRequestDto input);
        Task<Website> ConfiguratorRecommendedThemesAsync(Guid id, WebsiteConfiguratorRecommendedThemesRequestDto input);
        Task<Website> ConfiguratorSetMenuLinksAsync(Guid id, WebsiteConfiguratorSetMenuLinksRequestDto input);
        Task<Website> ConfiguratorSkipAsync(Guid id);
        Task<Website> CopyMenuHierarchyAsync(Guid id, WebsiteCopyMenuHierarchyRequestDto input);
        Task<Website> CreateAndRedirectConfiguratorAsync(Guid id);
        Task<Website> DashboardRedirectAsync(Guid id);
        Task<Website> GetCdnUrlAsync(Guid id, WebsiteGetCdnUrlRequestDto input);
        Task<Website> GetClientActionAsync(Guid id, WebsiteGetClientActionRequestDto input);
        Task<Website> GetClientUrlAsync(Guid id, WebsiteGetClientUrlRequestDto input);
        Task<Website> GetCtaDataAsync(Guid id, WebsiteGetCtaDataRequestDto input);
        Task<Website> GetCurrentWebsiteAsync(Guid id, WebsiteGetCurrentWebsiteRequestDto input);
        Task<Website> GetPricelistAvailableAsync(Guid id, WebsiteGetPricelistAvailableRequestDto input);
        Task<Website> GetSuggestedControllersAsync(Guid id);
        Task<Website> GetTemplateAsync(Guid id, WebsiteGetTemplateRequestDto input);
        Task<Website> GetThemeConfiguratorSnippetsAsync(Guid id, WebsiteGetThemeConfiguratorSnippetsRequestDto input);
        Task<Website> GetUniqueKeyAsync(Guid id, WebsiteGetUniqueKeyRequestDto input);
        Task<Website> GetUniquePathAsync(Guid id, WebsiteGetUniquePathRequestDto input);
        Task<Website> GetWebsitePageIdsAsync(Guid id);
        Task<Website> HasEcommerceAccessAsync(Guid id);
        Task<Website> HasGooglePlacesApiKeyAsync(Guid id);
        Task<Website> ImageUrlAsync(Guid id, WebsiteImageUrlRequestDto input);
        Task<Website> IsMenuCacheDisabledAsync(Guid id);
        Task<Website> IsPricelistAvailableAsync(Guid id, WebsiteIsPricelistAvailableRequestDto input);
        Task<Website> IsPublicUserAsync(Guid id);
        Task<Website> IsViewActiveAsync(Guid id, WebsiteIsViewActiveRequestDto input);
        Task<Website> NewPageAsync(Guid id, WebsiteNewPageRequestDto input);
        Task<Website> PagerAsync(Guid id, WebsitePagerRequestDto input);
        Task<Website> RuleIsEnumerableAsync(Guid id, WebsiteRuleIsEnumerableRequestDto input);
        Task<Website> SaleGetOrderAsync(Guid id, WebsiteSaleGetOrderRequestDto input);
        Task<Website> SaleProductDomainAsync(Guid id);
        Task<Website> SaleResetAsync(Guid id);
        Task<Website> SearchPagesAsync(Guid id, WebsiteSearchPagesRequestDto input);
        Task<Website> SearchUrlDependenciesAsync(Guid id, WebsiteSearchUrlDependenciesRequestDto input);
        Task<Website> ViewrefAsync(Guid id, WebsiteViewrefRequestDto input);
        Task<Website> WebsiteDomainAsync(Guid id, WebsiteWebsiteDomainRequestDto input);
    }
}