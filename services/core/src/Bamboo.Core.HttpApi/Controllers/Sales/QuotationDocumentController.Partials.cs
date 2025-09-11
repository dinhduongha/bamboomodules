using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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