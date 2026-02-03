using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrAttachmentController
    {
        
        [HttpPost]
        [Route("action-get")]
        public async Task<IActionResult> ActionGetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-preview-attachment")]
        public async Task<IActionResult> ActionPreviewAttachmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreviewAttachmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> CheckAsync(IrAttachmentCheckRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(IrAttachmentCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-unique")]
        public async Task<IActionResult> CreateUniqueAsync(IrAttachmentCreateUniqueRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateUniqueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("force-storage")]
        public async Task<IActionResult> ForceStorageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ForceStorageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-access-token")]
        public async Task<IActionResult> GenerateAccessTokenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateAccessTokenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-serving-groups")]
        public async Task<IActionResult> GetServingGroupsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetServingGroupsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("regenerate-assets-bundles")]
        public async Task<IActionResult> RegenerateAssetsBundlesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegenerateAssetsBundlesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("register-as-main-attachment")]
        public async Task<IActionResult> RegisterAsMainAttachmentAsync(IrAttachmentRegisterAsMainAttachmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RegisterAsMainAttachmentAsync(input);
            return Ok(result);
        }
    }
}