using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductDocumentController
    {
        
        [HttpPost]
        [Route("{id}/action-open-pdf-form-fields")]
        public async Task<IActionResult> ActionOpenPdfFormFieldsAsync(Guid id)
        {
            var result = await _appService.OpenPdfFormFieldsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ProductDocumentCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
    }
}