using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.SalePdfQuoteBuilder
{
    public partial class QuotationDocumentController
    {
        
        [HttpPost]
        [Route("{id}/action-open-pdf-form-fields")]
        public async Task<IActionResult> ActionOpenPdfFormFieldsAsync(Guid id)
        {
            var result = await _appService.OpenPdfFormFieldsAsync(id);
            return Ok(result);
        }
    }
}