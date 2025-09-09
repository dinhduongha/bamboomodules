using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrAttachmentController
    {
        
        [HttpPost]
        [Route("{id}/action-get")]
        public async Task<IActionResult> ActionGetAsync(Guid id)
        {
            var result = await _appService.GetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check")]
        public async Task<IActionResult> CheckAsync(Guid id, [FromBody] IrAttachmentCheckRequestDto input)
        {
            var result = await _appService.CheckAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrAttachmentCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-unique")]
        public async Task<IActionResult> CreateUniqueAsync(Guid id, [FromBody] IrAttachmentCreateUniqueRequestDto input)
        {
            var result = await _appService.CreateUniqueAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/force-storage")]
        public async Task<IActionResult> ForceStorageAsync(Guid id)
        {
            var result = await _appService.ForceStorageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-access-token")]
        public async Task<IActionResult> GenerateAccessTokenAsync(Guid id)
        {
            var result = await _appService.GenerateAccessTokenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-serving-groups")]
        public async Task<IActionResult> GetServingGroupsAsync(Guid id)
        {
            var result = await _appService.GetServingGroupsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/regenerate-assets-bundles")]
        public async Task<IActionResult> RegenerateAssetsBundlesAsync(Guid id)
        {
            var result = await _appService.RegenerateAssetsBundlesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/register-as-main-attachment")]
        public async Task<IActionResult> RegisterAsMainAttachmentAsync(Guid id, [FromBody] IrAttachmentRegisterAsMainAttachmentRequestDto input)
        {
            var result = await _appService.RegisterAsMainAttachmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-access")]
        public async Task<IActionResult> ValidateAccessAsync(Guid id, [FromBody] IrAttachmentValidateAccessRequestDto input)
        {
            var result = await _appService.ValidateAccessAsync(id, input);
            return Ok(result);
        }
    }
}