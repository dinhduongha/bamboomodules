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
    public interface IWebsiteAppService : IGenericApplicationService<Website>
    {
        Task<Website> ButtonGoWebsiteAsync(WebsiteButtonGoWebsiteRequestDto input);
        Task<Website> CheckExistingPageAsync(WebsiteCheckExistingPageRequestDto input);
        Task<Website> ConfiguratorAddonsApplyAsync(WebsiteConfiguratorAddonsApplyRequestDto input);
        Task<Website> ConfiguratorApplyAsync(Guid[] ids);
        Task<Website> ConfiguratorGetFooterLinksAsync(Guid[] ids);
        Task<Website> ConfiguratorInitAsync(Guid[] ids);
        Task<Website> ConfiguratorMissingIndustryAsync(WebsiteConfiguratorMissingIndustryRequestDto input);
        Task<Website> ConfiguratorRecommendedThemesAsync(WebsiteConfiguratorRecommendedThemesRequestDto input);
        Task<Website> ConfiguratorSetMenuLinksAsync(WebsiteConfiguratorSetMenuLinksRequestDto input);
        Task<Website> ConfiguratorSkipAsync(Guid[] ids);
        Task<Website> CopyMenuHierarchyAsync(WebsiteCopyMenuHierarchyRequestDto input);
        Task<Website> CreateAndRedirectConfiguratorAsync(Guid[] ids);
        Task<Website> DashboardRedirectAsync(Guid[] ids);
        Task<Website> GetCdnUrlAsync(WebsiteGetCdnUrlRequestDto input);
        Task<Website> GetClientActionAsync(WebsiteGetClientActionRequestDto input);
        Task<Website> GetClientUrlAsync(WebsiteGetClientUrlRequestDto input);
        Task<Website> GetConfiguratorProductPageStylesAsync(Guid[] ids);
        Task<Website> GetConfiguratorShopPageStylesAsync(Guid[] ids);
        Task<Website> GetCtaDataAsync(WebsiteGetCtaDataRequestDto input);
        Task<Website> GetCurrentWebsiteAsync(WebsiteGetCurrentWebsiteRequestDto input);
        Task<Website> GetPricelistAvailableAsync(WebsiteGetPricelistAvailableRequestDto input);
        Task<Website> GetSuggestedControllersAsync(Guid[] ids);
        Task<Website> GetTemplateAsync(WebsiteGetTemplateRequestDto input);
        Task<Website> GetThemeConfiguratorSnippetsAsync(WebsiteGetThemeConfiguratorSnippetsRequestDto input);
        Task<Website> GetUniqueKeyAsync(WebsiteGetUniqueKeyRequestDto input);
        Task<Website> GetUniquePathAsync(WebsiteGetUniquePathRequestDto input);
        Task<Website> GetWebsitePageIdsAsync(Guid[] ids);
        Task<Website> HasEcommerceAccessAsync(Guid[] ids);
        Task<Website> HasGooglePlacesApiKeyAsync(Guid[] ids);
        Task<Website> ImageUrlAsync(WebsiteImageUrlRequestDto input);
        Task<Website> IsMenuCacheDisabledAsync(Guid[] ids);
        Task<Website> IsPricelistAvailableAsync(WebsiteIsPricelistAvailableRequestDto input);
        Task<Website> IsPublicUserAsync(Guid[] ids);
        Task<Website> IsViewActiveAsync(WebsiteIsViewActiveRequestDto input);
        Task<Website> NewPageAsync(WebsiteNewPageRequestDto input);
        Task<Website> PagerAsync(WebsitePagerRequestDto input);
        Task<Website> RuleIsEnumerableAsync(WebsiteRuleIsEnumerableRequestDto input);
        Task<Website> SaleProductDomainAsync(Guid[] ids);
        Task<Website> SaleResetAsync(Guid[] ids);
        Task<Website> SearchPagesAsync(WebsiteSearchPagesRequestDto input);
        Task<Website> SearchUrlDependenciesAsync(WebsiteSearchUrlDependenciesRequestDto input);
        Task<Website> ViewrefAsync(WebsiteViewrefRequestDto input);
        Task<Website> WebsiteDomainAsync(Guid[] ids);
    }
}