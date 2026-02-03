using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BaseDocumentLayoutController
    {
        
        [HttpPost]
        [Route("document-layout-save")]
        public async Task<IActionResult> DocumentLayoutSaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DocumentLayoutSaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("extract-image-primary-secondary-colors")]
        public async Task<IActionResult> ExtractImagePrimarySecondaryColorsAsync(BaseDocumentLayoutExtractImagePrimarySecondaryColorsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExtractImagePrimarySecondaryColorsAsync(input);
            return Ok(result);
        }
    }
}