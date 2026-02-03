using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebsiteController
    {
        
        [HttpPost]
        [Route("action-dashboard-redirect")]
        public async Task<IActionResult> ActionDashboardRedirectAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DashboardRedirectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-go-website")]
        public async Task<IActionResult> ButtonGoWebsiteAsync(WebsiteButtonGoWebsiteRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ButtonGoWebsiteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-existing-page")]
        public async Task<IActionResult> CheckExistingPageAsync(WebsiteCheckExistingPageRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckExistingPageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-addons-apply")]
        public async Task<IActionResult> ConfiguratorAddonsApplyAsync(WebsiteConfiguratorAddonsApplyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfiguratorAddonsApplyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-apply")]
        public async Task<IActionResult> ConfiguratorApplyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfiguratorApplyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-get-footer-links")]
        public async Task<IActionResult> ConfiguratorGetFooterLinksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfiguratorGetFooterLinksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-init")]
        public async Task<IActionResult> ConfiguratorInitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfiguratorInitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-missing-industry")]
        public async Task<IActionResult> ConfiguratorMissingIndustryAsync(WebsiteConfiguratorMissingIndustryRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfiguratorMissingIndustryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-recommended-themes")]
        public async Task<IActionResult> ConfiguratorRecommendedThemesAsync(WebsiteConfiguratorRecommendedThemesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfiguratorRecommendedThemesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-set-menu-links")]
        public async Task<IActionResult> ConfiguratorSetMenuLinksAsync(WebsiteConfiguratorSetMenuLinksRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfiguratorSetMenuLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("configurator-skip")]
        public async Task<IActionResult> ConfiguratorSkipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfiguratorSkipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-menu-hierarchy")]
        public async Task<IActionResult> CopyMenuHierarchyAsync(WebsiteCopyMenuHierarchyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyMenuHierarchyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-and-redirect-configurator")]
        public async Task<IActionResult> CreateAndRedirectConfiguratorAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateAndRedirectConfiguratorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cdn-url")]
        public async Task<IActionResult> GetCdnUrlAsync(WebsiteGetCdnUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCdnUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-client-action")]
        public async Task<IActionResult> GetClientActionAsync(WebsiteGetClientActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetClientActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-client-action-url")]
        public async Task<IActionResult> GetClientActionUrlAsync(WebsiteGetClientUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetClientUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-configurator-product-page-styles")]
        public async Task<IActionResult> GetConfiguratorProductPageStylesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetConfiguratorProductPageStylesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-configurator-shop-page-styles")]
        public async Task<IActionResult> GetConfiguratorShopPageStylesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetConfiguratorShopPageStylesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-cta-data")]
        public async Task<IActionResult> GetCtaDataAsync(WebsiteGetCtaDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCtaDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-website")]
        public async Task<IActionResult> GetCurrentWebsiteAsync(WebsiteGetCurrentWebsiteRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCurrentWebsiteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pricelist-available")]
        public async Task<IActionResult> GetPricelistAvailableAsync(WebsiteGetPricelistAvailableRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetPricelistAvailableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-suggested-controllers")]
        public async Task<IActionResult> GetSuggestedControllersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSuggestedControllersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-template")]
        public async Task<IActionResult> GetTemplateAsync(WebsiteGetTemplateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-theme-configurator-snippets")]
        public async Task<IActionResult> GetThemeConfiguratorSnippetsAsync(WebsiteGetThemeConfiguratorSnippetsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetThemeConfiguratorSnippetsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unique-key")]
        public async Task<IActionResult> GetUniqueKeyAsync(WebsiteGetUniqueKeyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUniqueKeyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unique-path")]
        public async Task<IActionResult> GetUniquePathAsync(WebsiteGetUniquePathRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUniquePathAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-website-page-ids")]
        public async Task<IActionResult> GetWebsitePageIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetWebsitePageIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-ecommerce-access")]
        public async Task<IActionResult> HasEcommerceAccessAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasEcommerceAccessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-google-places-api-key")]
        public async Task<IActionResult> HasGooglePlacesApiKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasGooglePlacesApiKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("image-url")]
        public async Task<IActionResult> ImageUrlAsync(WebsiteImageUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ImageUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-menu-cache-disabled")]
        public async Task<IActionResult> IsMenuCacheDisabledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsMenuCacheDisabledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-pricelist-available")]
        public async Task<IActionResult> IsPricelistAvailableAsync(WebsiteIsPricelistAvailableRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsPricelistAvailableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-public-user")]
        public async Task<IActionResult> IsPublicUserAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsPublicUserAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-view-active")]
        public async Task<IActionResult> IsViewActiveAsync(WebsiteIsViewActiveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsViewActiveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new-page")]
        public async Task<IActionResult> NewPageAsync(WebsiteNewPageRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NewPageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pager")]
        public async Task<IActionResult> PagerAsync(WebsitePagerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PagerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rule-is-enumerable")]
        public async Task<IActionResult> RuleIsEnumerableAsync(WebsiteRuleIsEnumerableRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RuleIsEnumerableAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sale-product-domain")]
        public async Task<IActionResult> SaleProductDomainAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SaleProductDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sale-reset")]
        public async Task<IActionResult> SaleResetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SaleResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-pages")]
        public async Task<IActionResult> SearchPagesAsync(WebsiteSearchPagesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchPagesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-url-dependencies")]
        public async Task<IActionResult> SearchUrlDependenciesAsync(WebsiteSearchUrlDependenciesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchUrlDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viewref")]
        public async Task<IActionResult> ViewrefAsync(WebsiteViewrefRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ViewrefAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-domain")]
        public async Task<IActionResult> WebsiteDomainAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebsiteDomainAsync(ids);
            return Ok(result);
        }
    }
}