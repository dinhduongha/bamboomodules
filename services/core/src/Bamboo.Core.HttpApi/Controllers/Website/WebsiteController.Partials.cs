using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebsiteController
    {
        
        [HttpPost]
        [Route("{id}/action-dashboard-redirect")]
        public async Task<IActionResult> ActionDashboardRedirectAsync(Guid id)
        {
            var result = await _appService.DashboardRedirectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-go-website")]
        public async Task<IActionResult> ButtonGoWebsiteAsync(Guid id, [FromBody] WebsiteButtonGoWebsiteRequestDto input)
        {
            var result = await _appService.ButtonGoWebsiteAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-apply")]
        public async Task<IActionResult> ConfiguratorApplyAsync(Guid id)
        {
            var result = await _appService.ConfiguratorApplyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-get-footer-links")]
        public async Task<IActionResult> ConfiguratorGetFooterLinksAsync(Guid id)
        {
            var result = await _appService.ConfiguratorGetFooterLinksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-init")]
        public async Task<IActionResult> ConfiguratorInitAsync(Guid id)
        {
            var result = await _appService.ConfiguratorInitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-missing-industry")]
        public async Task<IActionResult> ConfiguratorMissingIndustryAsync(Guid id, [FromBody] WebsiteConfiguratorMissingIndustryRequestDto input)
        {
            var result = await _appService.ConfiguratorMissingIndustryAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-recommended-themes")]
        public async Task<IActionResult> ConfiguratorRecommendedThemesAsync(Guid id, [FromBody] WebsiteConfiguratorRecommendedThemesRequestDto input)
        {
            var result = await _appService.ConfiguratorRecommendedThemesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-set-menu-links")]
        public async Task<IActionResult> ConfiguratorSetMenuLinksAsync(Guid id, [FromBody] WebsiteConfiguratorSetMenuLinksRequestDto input)
        {
            var result = await _appService.ConfiguratorSetMenuLinksAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/configurator-skip")]
        public async Task<IActionResult> ConfiguratorSkipAsync(Guid id)
        {
            var result = await _appService.ConfiguratorSkipAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-menu-hierarchy")]
        public async Task<IActionResult> CopyMenuHierarchyAsync(Guid id, [FromBody] WebsiteCopyMenuHierarchyRequestDto input)
        {
            var result = await _appService.CopyMenuHierarchyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-and-redirect-configurator")]
        public async Task<IActionResult> CreateAndRedirectConfiguratorAsync(Guid id)
        {
            var result = await _appService.CreateAndRedirectConfiguratorAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-cdn-url")]
        public async Task<IActionResult> GetCdnUrlAsync(Guid id, [FromBody] WebsiteGetCdnUrlRequestDto input)
        {
            var result = await _appService.GetCdnUrlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-client-action")]
        public async Task<IActionResult> GetClientActionAsync(Guid id, [FromBody] WebsiteGetClientActionRequestDto input)
        {
            var result = await _appService.GetClientActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-client-action-url")]
        public async Task<IActionResult> GetClientActionUrlAsync(Guid id, [FromBody] WebsiteGetClientUrlRequestDto input)
        {
            var result = await _appService.GetClientUrlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-cta-data")]
        public async Task<IActionResult> GetCtaDataAsync(Guid id, [FromBody] WebsiteGetCtaDataRequestDto input)
        {
            var result = await _appService.GetCtaDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-current-website")]
        public async Task<IActionResult> GetCurrentWebsiteAsync(Guid id, [FromBody] WebsiteGetCurrentWebsiteRequestDto input)
        {
            var result = await _appService.GetCurrentWebsiteAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-pricelist-available")]
        public async Task<IActionResult> GetPricelistAvailableAsync(Guid id, [FromBody] WebsiteGetPricelistAvailableRequestDto input)
        {
            var result = await _appService.GetPricelistAvailableAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-suggested-controllers")]
        public async Task<IActionResult> GetSuggestedControllersAsync(Guid id)
        {
            var result = await _appService.GetSuggestedControllersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-template")]
        public async Task<IActionResult> GetTemplateAsync(Guid id, [FromBody] WebsiteGetTemplateRequestDto input)
        {
            var result = await _appService.GetTemplateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-theme-configurator-snippets")]
        public async Task<IActionResult> GetThemeConfiguratorSnippetsAsync(Guid id, [FromBody] WebsiteGetThemeConfiguratorSnippetsRequestDto input)
        {
            var result = await _appService.GetThemeConfiguratorSnippetsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unique-key")]
        public async Task<IActionResult> GetUniqueKeyAsync(Guid id, [FromBody] WebsiteGetUniqueKeyRequestDto input)
        {
            var result = await _appService.GetUniqueKeyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unique-path")]
        public async Task<IActionResult> GetUniquePathAsync(Guid id, [FromBody] WebsiteGetUniquePathRequestDto input)
        {
            var result = await _appService.GetUniquePathAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-website-page-ids")]
        public async Task<IActionResult> GetWebsitePageIdsAsync(Guid id)
        {
            var result = await _appService.GetWebsitePageIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-ecommerce-access")]
        public async Task<IActionResult> HasEcommerceAccessAsync(Guid id)
        {
            var result = await _appService.HasEcommerceAccessAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-google-places-api-key")]
        public async Task<IActionResult> HasGooglePlacesApiKeyAsync(Guid id)
        {
            var result = await _appService.HasGooglePlacesApiKeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/image-url")]
        public async Task<IActionResult> ImageUrlAsync(Guid id, [FromBody] WebsiteImageUrlRequestDto input)
        {
            var result = await _appService.ImageUrlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-menu-cache-disabled")]
        public async Task<IActionResult> IsMenuCacheDisabledAsync(Guid id)
        {
            var result = await _appService.IsMenuCacheDisabledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-pricelist-available")]
        public async Task<IActionResult> IsPricelistAvailableAsync(Guid id, [FromBody] WebsiteIsPricelistAvailableRequestDto input)
        {
            var result = await _appService.IsPricelistAvailableAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-public-user")]
        public async Task<IActionResult> IsPublicUserAsync(Guid id)
        {
            var result = await _appService.IsPublicUserAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-view-active")]
        public async Task<IActionResult> IsViewActiveAsync(Guid id, [FromBody] WebsiteIsViewActiveRequestDto input)
        {
            var result = await _appService.IsViewActiveAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/new-page")]
        public async Task<IActionResult> NewPageAsync(Guid id, [FromBody] WebsiteNewPageRequestDto input)
        {
            var result = await _appService.NewPageAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pager")]
        public async Task<IActionResult> PagerAsync(Guid id, [FromBody] WebsitePagerRequestDto input)
        {
            var result = await _appService.PagerAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/rule-is-enumerable")]
        public async Task<IActionResult> RuleIsEnumerableAsync(Guid id, [FromBody] WebsiteRuleIsEnumerableRequestDto input)
        {
            var result = await _appService.RuleIsEnumerableAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sale-get-order")]
        public async Task<IActionResult> SaleGetOrderAsync(Guid id, [FromBody] WebsiteSaleGetOrderRequestDto input)
        {
            var result = await _appService.SaleGetOrderAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sale-product-domain")]
        public async Task<IActionResult> SaleProductDomainAsync(Guid id)
        {
            var result = await _appService.SaleProductDomainAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sale-reset")]
        public async Task<IActionResult> SaleResetAsync(Guid id)
        {
            var result = await _appService.SaleResetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-pages")]
        public async Task<IActionResult> SearchPagesAsync(Guid id, [FromBody] WebsiteSearchPagesRequestDto input)
        {
            var result = await _appService.SearchPagesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-url-dependencies")]
        public async Task<IActionResult> SearchUrlDependenciesAsync(Guid id, [FromBody] WebsiteSearchUrlDependenciesRequestDto input)
        {
            var result = await _appService.SearchUrlDependenciesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viewref")]
        public async Task<IActionResult> ViewrefAsync(Guid id, [FromBody] WebsiteViewrefRequestDto input)
        {
            var result = await _appService.ViewrefAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/website-domain")]
        public async Task<IActionResult> WebsiteDomainAsync(Guid id, [FromBody] WebsiteWebsiteDomainRequestDto input)
        {
            var result = await _appService.WebsiteDomainAsync(id, input);
            return Ok(result);
        }
    }
}