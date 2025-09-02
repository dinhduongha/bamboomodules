using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Web
{
    public partial class BaseDocumentLayoutController
    {
        
        [HttpPost]
        [Route("{id}/document-layout-save")]
        public async Task<IActionResult> DocumentLayoutSaveAsync(Guid id)
        {
            var result = await _appService.DocumentLayoutSaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/extract-image-primary-secondary-colors")]
        public async Task<IActionResult> ExtractImagePrimarySecondaryColorsAsync(Guid id, [FromBody] BaseDocumentLayoutExtractImagePrimarySecondaryColorsRequestDto input)
        {
            var result = await _appService.ExtractImagePrimarySecondaryColorsAsync(id, input);
            return Ok(result);
        }
    }
}