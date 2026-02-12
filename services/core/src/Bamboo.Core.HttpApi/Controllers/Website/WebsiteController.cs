using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/website/Website")]
    public partial class WebsiteController : AbpController
    {
        protected readonly IWebsiteAppService _appService;
        public WebsiteController(IWebsiteAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-dashboard-redirect")]
        public async Task<IActionResult> DashboardRedirectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DashboardRedirectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-go-website")]
        public async Task<IActionResult> ButtonGoWebsiteAsync([FromBody] WebsiteButtonGoWebsiteRequestDto input)
        {
            var result = await _appService.ButtonGoWebsiteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-existing-page")]
        public async Task<IActionResult> CheckExistingPageAsync([FromBody] WebsiteCheckExistingPageRequestDto input)
        {
            var result = await _appService.CheckExistingPageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-addons-apply")]
        public async Task<IActionResult> ConfiguratorAddonsApplyAsync([FromBody] WebsiteConfiguratorAddonsApplyRequestDto input)
        {
            var result = await _appService.ConfiguratorAddonsApplyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-apply")]
        public async Task<IActionResult> ConfiguratorApplyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfiguratorApplyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-get-footer-links")]
        public async Task<IActionResult> ConfiguratorGetFooterLinksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfiguratorGetFooterLinksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-init")]
        public async Task<IActionResult> ConfiguratorInitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfiguratorInitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-missing-industry")]
        public async Task<IActionResult> ConfiguratorMissingIndustryAsync([FromBody] WebsiteConfiguratorMissingIndustryRequestDto input)
        {
            var result = await _appService.ConfiguratorMissingIndustryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-recommended-themes")]
        public async Task<IActionResult> ConfiguratorRecommendedThemesAsync([FromBody] WebsiteConfiguratorRecommendedThemesRequestDto input)
        {
            var result = await _appService.ConfiguratorRecommendedThemesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-set-menu-links")]
        public async Task<IActionResult> ConfiguratorSetMenuLinksAsync([FromBody] WebsiteConfiguratorSetMenuLinksRequestDto input)
        {
            var result = await _appService.ConfiguratorSetMenuLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-skip")]
        public async Task<IActionResult> ConfiguratorSkipAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfiguratorSkipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-menu-hierarchy")]
        public async Task<IActionResult> CopyMenuHierarchyAsync([FromBody] WebsiteCopyMenuHierarchyRequestDto input)
        {
            var result = await _appService.CopyMenuHierarchyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-and-redirect-configurator")]
        public async Task<IActionResult> CreateAndRedirectConfiguratorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateAndRedirectConfiguratorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cdn-url")]
        public async Task<IActionResult> GetCdnUrlAsync([FromBody] WebsiteGetCdnUrlRequestDto input)
        {
            var result = await _appService.GetCdnUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-client-action")]
        public async Task<IActionResult> GetClientActionAsync([FromBody] WebsiteGetClientActionRequestDto input)
        {
            var result = await _appService.GetClientActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-client-action-url")]
        public async Task<IActionResult> GetClientUrlAsync([FromBody] WebsiteGetClientUrlRequestDto input)
        {
            var result = await _appService.GetClientUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-configurator-product-page-styles")]
        public async Task<IActionResult> GetConfiguratorProductPageStylesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetConfiguratorProductPageStylesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-configurator-shop-page-styles")]
        public async Task<IActionResult> GetConfiguratorShopPageStylesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetConfiguratorShopPageStylesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cta-data")]
        public async Task<IActionResult> GetCtaDataAsync([FromBody] WebsiteGetCtaDataRequestDto input)
        {
            var result = await _appService.GetCtaDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-website")]
        public async Task<IActionResult> GetCurrentWebsiteAsync([FromBody] WebsiteGetCurrentWebsiteRequestDto input)
        {
            var result = await _appService.GetCurrentWebsiteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pricelist-available")]
        public async Task<IActionResult> GetPricelistAvailableAsync([FromBody] WebsiteGetPricelistAvailableRequestDto input)
        {
            var result = await _appService.GetPricelistAvailableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-suggested-controllers")]
        public async Task<IActionResult> GetSuggestedControllersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSuggestedControllersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-template")]
        public async Task<IActionResult> GetTemplateAsync([FromBody] WebsiteGetTemplateRequestDto input)
        {
            var result = await _appService.GetTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-theme-configurator-snippets")]
        public async Task<IActionResult> GetThemeConfiguratorSnippetsAsync([FromBody] WebsiteGetThemeConfiguratorSnippetsRequestDto input)
        {
            var result = await _appService.GetThemeConfiguratorSnippetsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unique-key")]
        public async Task<IActionResult> GetUniqueKeyAsync([FromBody] WebsiteGetUniqueKeyRequestDto input)
        {
            var result = await _appService.GetUniqueKeyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unique-path")]
        public async Task<IActionResult> GetUniquePathAsync([FromBody] WebsiteGetUniquePathRequestDto input)
        {
            var result = await _appService.GetUniquePathAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-website-page-ids")]
        public async Task<IActionResult> GetWebsitePageIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetWebsitePageIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-ecommerce-access")]
        public async Task<IActionResult> HasEcommerceAccessAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasEcommerceAccessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-google-places-api-key")]
        public async Task<IActionResult> HasGooglePlacesApiKeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasGooglePlacesApiKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("image-url")]
        public async Task<IActionResult> ImageUrlAsync([FromBody] WebsiteImageUrlRequestDto input)
        {
            var result = await _appService.ImageUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-menu-cache-disabled")]
        public async Task<IActionResult> IsMenuCacheDisabledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IsMenuCacheDisabledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-pricelist-available")]
        public async Task<IActionResult> IsPricelistAvailableAsync([FromBody] WebsiteIsPricelistAvailableRequestDto input)
        {
            var result = await _appService.IsPricelistAvailableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-public-user")]
        public async Task<IActionResult> IsPublicUserAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IsPublicUserAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-view-active")]
        public async Task<IActionResult> IsViewActiveAsync([FromBody] WebsiteIsViewActiveRequestDto input)
        {
            var result = await _appService.IsViewActiveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new-page")]
        public async Task<IActionResult> NewPageAsync([FromBody] WebsiteNewPageRequestDto input)
        {
            var result = await _appService.NewPageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pager")]
        public async Task<IActionResult> PagerAsync([FromBody] WebsitePagerRequestDto input)
        {
            var result = await _appService.PagerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rule-is-enumerable")]
        public async Task<IActionResult> RuleIsEnumerableAsync([FromBody] WebsiteRuleIsEnumerableRequestDto input)
        {
            var result = await _appService.RuleIsEnumerableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sale-product-domain")]
        public async Task<IActionResult> SaleProductDomainAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaleProductDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sale-reset")]
        public async Task<IActionResult> SaleResetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaleResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-pages")]
        public async Task<IActionResult> SearchPagesAsync([FromBody] WebsiteSearchPagesRequestDto input)
        {
            var result = await _appService.SearchPagesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-url-dependencies")]
        public async Task<IActionResult> SearchUrlDependenciesAsync([FromBody] WebsiteSearchUrlDependenciesRequestDto input)
        {
            var result = await _appService.SearchUrlDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viewref")]
        public async Task<IActionResult> ViewrefAsync([FromBody] WebsiteViewrefRequestDto input)
        {
            var result = await _appService.ViewrefAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-domain")]
        public async Task<IActionResult> WebsiteDomainAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WebsiteDomainAsync(ids);
            return Ok(result);
        }
    }
    
}