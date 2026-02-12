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
    [Route("api/v1/web/BaseDocumentLayout")]
    public partial class BaseDocumentLayoutController : AbpController
    {
        protected readonly IBaseDocumentLayoutAppService _appService;
        public BaseDocumentLayoutController(IBaseDocumentLayoutAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("document-layout-save")]
        public async Task<IActionResult> DocumentLayoutSaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DocumentLayoutSaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-image-primary-secondary-colors")]
        public async Task<IActionResult> ExtractImagePrimarySecondaryColorsAsync([FromBody] BaseDocumentLayoutExtractImagePrimarySecondaryColorsRequestDto input)
        {
            var result = await _appService.ExtractImagePrimarySecondaryColorsAsync(input);
            return Ok(result);
        }
    }
    
}