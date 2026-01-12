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
        [Route("{id}/apply-inheritance-specs")]
        public async Task<IActionResult> ApplyInheritanceSpecsAsync(Guid id, [FromBody] IrUiViewApplyInheritanceSpecsRequestDto input)
        {
            var result = await _appService.ApplyInheritanceSpecsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrUiViewCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/default-view")]
        public async Task<IActionResult> DefaultViewAsync(Guid id, [FromBody] IrUiViewDefaultViewRequestDto input)
        {
            var result = await _appService.DefaultViewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/delete-snippet")]
        public async Task<IActionResult> DeleteSnippetAsync(Guid id, [FromBody] IrUiViewDeleteSnippetRequestDto input)
        {
            var result = await _appService.DeleteSnippetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/distribute-branding")]
        public async Task<IActionResult> DistributeBrandingAsync(Guid id, [FromBody] IrUiViewDistributeBrandingRequestDto input)
        {
            var result = await _appService.DistributeBrandingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/extract-embedded-fields")]
        public async Task<IActionResult> ExtractEmbeddedFieldsAsync(Guid id, [FromBody] IrUiViewExtractEmbeddedFieldsRequestDto input)
        {
            var result = await _appService.ExtractEmbeddedFieldsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/extract-oe-structures")]
        public async Task<IActionResult> ExtractOeStructuresAsync(Guid id, [FromBody] IrUiViewExtractOeStructuresRequestDto input)
        {
            var result = await _appService.ExtractOeStructuresAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync(Guid id)
        {
            var result = await _appService.FilterDuplicateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-combined-arch")]
        public async Task<IActionResult> GetCombinedArchAsync(Guid id)
        {
            var result = await _appService.GetCombinedArchAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-default-lang-code")]
        public async Task<IActionResult> GetDefaultLangCodeAsync(Guid id)
        {
            var result = await _appService.GetDefaultLangCodeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-related-views")]
        public async Task<IActionResult> GetRelatedViewsAsync(Guid id, [FromBody] IrUiViewGetRelatedViewsRequestDto input)
        {
            var result = await _appService.GetRelatedViewsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-view-hierarchy")]
        public async Task<IActionResult> GetViewHierarchyAsync(Guid id)
        {
            var result = await _appService.GetViewHierarchyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-view-info")]
        public async Task<IActionResult> GetViewInfoAsync(Guid id)
        {
            var result = await _appService.GetViewInfoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/inherit-branding")]
        public async Task<IActionResult> InheritBrandingAsync(Guid id, [FromBody] IrUiViewInheritBrandingRequestDto input)
        {
            var result = await _appService.InheritBrandingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-node-branded")]
        public async Task<IActionResult> IsNodeBrandedAsync(Guid id, [FromBody] IrUiViewIsNodeBrandedRequestDto input)
        {
            var result = await _appService.IsNodeBrandedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/locate-node")]
        public async Task<IActionResult> LocateNodeAsync(Guid id, [FromBody] IrUiViewLocateNodeRequestDto input)
        {
            var result = await _appService.LocateNodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/postprocess-and-fields")]
        public async Task<IActionResult> PostprocessAndFieldsAsync(Guid id, [FromBody] IrUiViewPostprocessAndFieldsRequestDto input)
        {
            var result = await _appService.PostprocessAndFieldsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/rename-snippet")]
        public async Task<IActionResult> RenameSnippetAsync(Guid id, [FromBody] IrUiViewRenameSnippetRequestDto input)
        {
            var result = await _appService.RenameSnippetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/render-public-asset")]
        public async Task<IActionResult> RenderPublicAssetAsync(Guid id, [FromBody] IrUiViewRenderPublicAssetRequestDto input)
        {
            var result = await _appService.RenderPublicAssetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/replace-arch-section")]
        public async Task<IActionResult> ReplaceArchSectionAsync(Guid id, [FromBody] IrUiViewReplaceArchSectionRequestDto input)
        {
            var result = await _appService.ReplaceArchSectionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset-arch")]
        public async Task<IActionResult> ResetArchAsync(Guid id, [FromBody] IrUiViewResetArchRequestDto input)
        {
            var result = await _appService.ResetArchAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save")]
        public async Task<IActionResult> SaveAsync(Guid id, [FromBody] IrUiViewSaveRequestDto input)
        {
            var result = await _appService.SaveAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save-embedded-field")]
        public async Task<IActionResult> SaveEmbeddedFieldAsync(Guid id, [FromBody] IrUiViewSaveEmbeddedFieldRequestDto input)
        {
            var result = await _appService.SaveEmbeddedFieldAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save-oe-structure")]
        public async Task<IActionResult> SaveOeStructureAsync(Guid id, [FromBody] IrUiViewSaveOeStructureRequestDto input)
        {
            var result = await _appService.SaveOeStructureAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save-snippet")]
        public async Task<IActionResult> SaveSnippetAsync(Guid id, [FromBody] IrUiViewSaveSnippetRequestDto input)
        {
            var result = await _appService.SaveSnippetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/to-empty-oe-structure")]
        public async Task<IActionResult> ToEmptyOeStructureAsync(Guid id, [FromBody] IrUiViewToEmptyOeStructureRequestDto input)
        {
            var result = await _appService.ToEmptyOeStructureAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/to-field-ref")]
        public async Task<IActionResult> ToFieldRefAsync(Guid id, [FromBody] IrUiViewToFieldRefRequestDto input)
        {
            var result = await _appService.ToFieldRefAsync(id, input);
            return Ok(result);
        }
    }
}