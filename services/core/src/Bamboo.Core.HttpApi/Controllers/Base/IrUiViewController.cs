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
    [Route("api/v1/base/IrUiView")]
    public partial class IrUiViewController : AbpController
    {
        protected readonly IIrUiViewAppService _appService;
        public IrUiViewController(IIrUiViewAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("apply-inheritance-specs")]
        public async Task<IActionResult> ApplyInheritanceSpecsAsync([FromBody] IrUiViewApplyInheritanceSpecsRequestDto input)
        {
            var result = await _appService.ApplyInheritanceSpecsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] IrUiViewCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("default-view")]
        public async Task<IActionResult> DefaultViewAsync([FromBody] IrUiViewDefaultViewRequestDto input)
        {
            var result = await _appService.DefaultViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-snippet")]
        public async Task<IActionResult> DeleteSnippetAsync([FromBody] IrUiViewDeleteSnippetRequestDto input)
        {
            var result = await _appService.DeleteSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("distribute-branding")]
        public async Task<IActionResult> DistributeBrandingAsync([FromBody] IrUiViewDistributeBrandingRequestDto input)
        {
            var result = await _appService.DistributeBrandingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-embedded-fields")]
        public async Task<IActionResult> ExtractEmbeddedFieldsAsync([FromBody] IrUiViewExtractEmbeddedFieldsRequestDto input)
        {
            var result = await _appService.ExtractEmbeddedFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-oe-structures")]
        public async Task<IActionResult> ExtractOeStructuresAsync([FromBody] IrUiViewExtractOeStructuresRequestDto input)
        {
            var result = await _appService.ExtractOeStructuresAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FilterDuplicateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-combined-arch")]
        public async Task<IActionResult> GetCombinedArchAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCombinedArchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-default-lang-code")]
        public async Task<IActionResult> GetDefaultLangCodeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDefaultLangCodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-related-views")]
        public async Task<IActionResult> GetRelatedViewsAsync([FromBody] IrUiViewGetRelatedViewsRequestDto input)
        {
            var result = await _appService.GetRelatedViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view-hierarchy")]
        public async Task<IActionResult> GetViewHierarchyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetViewHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view-info")]
        public async Task<IActionResult> GetViewInfoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetViewInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("inherit-branding")]
        public async Task<IActionResult> InheritBrandingAsync([FromBody] IrUiViewInheritBrandingRequestDto input)
        {
            var result = await _appService.InheritBrandingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-node-branded")]
        public async Task<IActionResult> IsNodeBrandedAsync([FromBody] IrUiViewIsNodeBrandedRequestDto input)
        {
            var result = await _appService.IsNodeBrandedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("locate-node")]
        public async Task<IActionResult> LocateNodeAsync([FromBody] IrUiViewLocateNodeRequestDto input)
        {
            var result = await _appService.LocateNodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("postprocess-and-fields")]
        public async Task<IActionResult> PostprocessAndFieldsAsync([FromBody] IrUiViewPostprocessAndFieldsRequestDto input)
        {
            var result = await _appService.PostprocessAndFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rename-snippet")]
        public async Task<IActionResult> RenameSnippetAsync([FromBody] IrUiViewRenameSnippetRequestDto input)
        {
            var result = await _appService.RenameSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("render-public-asset")]
        public async Task<IActionResult> RenderPublicAssetAsync([FromBody] IrUiViewRenderPublicAssetRequestDto input)
        {
            var result = await _appService.RenderPublicAssetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("replace-arch-section")]
        public async Task<IActionResult> ReplaceArchSectionAsync([FromBody] IrUiViewReplaceArchSectionRequestDto input)
        {
            var result = await _appService.ReplaceArchSectionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-arch")]
        public async Task<IActionResult> ResetArchAsync([FromBody] IrUiViewResetArchRequestDto input)
        {
            var result = await _appService.ResetArchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync([FromBody] IrUiViewSaveRequestDto input)
        {
            var result = await _appService.SaveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-embedded-field")]
        public async Task<IActionResult> SaveEmbeddedFieldAsync([FromBody] IrUiViewSaveEmbeddedFieldRequestDto input)
        {
            var result = await _appService.SaveEmbeddedFieldAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-oe-structure")]
        public async Task<IActionResult> SaveOeStructureAsync([FromBody] IrUiViewSaveOeStructureRequestDto input)
        {
            var result = await _appService.SaveOeStructureAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-snippet")]
        public async Task<IActionResult> SaveSnippetAsync([FromBody] IrUiViewSaveSnippetRequestDto input)
        {
            var result = await _appService.SaveSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("to-empty-oe-structure")]
        public async Task<IActionResult> ToEmptyOeStructureAsync([FromBody] IrUiViewToEmptyOeStructureRequestDto input)
        {
            var result = await _appService.ToEmptyOeStructureAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("to-field-ref")]
        public async Task<IActionResult> ToFieldRefAsync([FromBody] IrUiViewToFieldRefRequestDto input)
        {
            var result = await _appService.ToFieldRefAsync(input);
            return Ok(result);
        }
    }
    
}