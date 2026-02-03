using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrUiViewController
    {
        
        [HttpPost]
        [Route("apply-inheritance-specs")]
        public async Task<IActionResult> ApplyInheritanceSpecsAsync(IrUiViewApplyInheritanceSpecsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ApplyInheritanceSpecsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(IrUiViewCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("default-view")]
        public async Task<IActionResult> DefaultViewAsync(IrUiViewDefaultViewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DefaultViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("delete-snippet")]
        public async Task<IActionResult> DeleteSnippetAsync(IrUiViewDeleteSnippetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DeleteSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("distribute-branding")]
        public async Task<IActionResult> DistributeBrandingAsync(IrUiViewDistributeBrandingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DistributeBrandingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-embedded-fields")]
        public async Task<IActionResult> ExtractEmbeddedFieldsAsync(IrUiViewExtractEmbeddedFieldsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExtractEmbeddedFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-oe-structures")]
        public async Task<IActionResult> ExtractOeStructuresAsync(IrUiViewExtractOeStructuresRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExtractOeStructuresAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FilterDuplicateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-combined-arch")]
        public async Task<IActionResult> GetCombinedArchAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCombinedArchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-default-lang-code")]
        public async Task<IActionResult> GetDefaultLangCodeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDefaultLangCodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-related-views")]
        public async Task<IActionResult> GetRelatedViewsAsync(IrUiViewGetRelatedViewsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetRelatedViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view-hierarchy")]
        public async Task<IActionResult> GetViewHierarchyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetViewHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view-info")]
        public async Task<IActionResult> GetViewInfoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetViewInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("inherit-branding")]
        public async Task<IActionResult> InheritBrandingAsync(IrUiViewInheritBrandingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.InheritBrandingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-node-branded")]
        public async Task<IActionResult> IsNodeBrandedAsync(IrUiViewIsNodeBrandedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsNodeBrandedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("locate-node")]
        public async Task<IActionResult> LocateNodeAsync(IrUiViewLocateNodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LocateNodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("postprocess-and-fields")]
        public async Task<IActionResult> PostprocessAndFieldsAsync(IrUiViewPostprocessAndFieldsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PostprocessAndFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rename-snippet")]
        public async Task<IActionResult> RenameSnippetAsync(IrUiViewRenameSnippetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RenameSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("render-public-asset")]
        public async Task<IActionResult> RenderPublicAssetAsync(IrUiViewRenderPublicAssetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RenderPublicAssetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("replace-arch-section")]
        public async Task<IActionResult> ReplaceArchSectionAsync(IrUiViewReplaceArchSectionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReplaceArchSectionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-arch")]
        public async Task<IActionResult> ResetArchAsync(IrUiViewResetArchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ResetArchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync(IrUiViewSaveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SaveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-embedded-field")]
        public async Task<IActionResult> SaveEmbeddedFieldAsync(IrUiViewSaveEmbeddedFieldRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SaveEmbeddedFieldAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-oe-structure")]
        public async Task<IActionResult> SaveOeStructureAsync(IrUiViewSaveOeStructureRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SaveOeStructureAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save-snippet")]
        public async Task<IActionResult> SaveSnippetAsync(IrUiViewSaveSnippetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SaveSnippetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("to-empty-oe-structure")]
        public async Task<IActionResult> ToEmptyOeStructureAsync(IrUiViewToEmptyOeStructureRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToEmptyOeStructureAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("to-field-ref")]
        public async Task<IActionResult> ToFieldRefAsync(IrUiViewToFieldRefRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToFieldRefAsync(input);
            return Ok(result);
        }
    }
}