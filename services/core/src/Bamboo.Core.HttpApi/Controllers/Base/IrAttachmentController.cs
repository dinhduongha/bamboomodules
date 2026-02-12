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
    [Route("api/v1/base/IrAttachment")]
    public partial class IrAttachmentController : AbpController
    {
        protected readonly IIrAttachmentAppService _appService;
        public IrAttachmentController(IIrAttachmentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-get")]
        public async Task<IActionResult> GetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-preview-attachment")]
        public async Task<IActionResult> PreviewAttachmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreviewAttachmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> CheckAsync([FromBody] IrAttachmentCheckRequestDto input)
        {
            var result = await _appService.CheckAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] IrAttachmentCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-unique")]
        public async Task<IActionResult> CreateUniqueAsync([FromBody] IrAttachmentCreateUniqueRequestDto input)
        {
            var result = await _appService.CreateUniqueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("force-storage")]
        public async Task<IActionResult> ForceStorageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ForceStorageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-access-token")]
        public async Task<IActionResult> GenerateAccessTokenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GenerateAccessTokenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-serving-groups")]
        public async Task<IActionResult> GetServingGroupsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetServingGroupsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("regenerate-assets-bundles")]
        public async Task<IActionResult> RegenerateAssetsBundlesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RegenerateAssetsBundlesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("register-as-main-attachment")]
        public async Task<IActionResult> RegisterAsMainAttachmentAsync([FromBody] IrAttachmentRegisterAsMainAttachmentRequestDto input)
        {
            var result = await _appService.RegisterAsMainAttachmentAsync(input);
            return Ok(result);
        }
    }
    
}