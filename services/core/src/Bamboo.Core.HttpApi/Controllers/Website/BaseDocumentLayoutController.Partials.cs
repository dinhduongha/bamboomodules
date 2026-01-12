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