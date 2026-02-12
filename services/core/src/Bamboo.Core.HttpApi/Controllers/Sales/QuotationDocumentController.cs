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
    [Route("api/v1/sales/QuotationDocument")]
    public partial class QuotationDocumentController : AbpController
    {
        protected readonly IQuotationDocumentAppService _appService;
        public QuotationDocumentController(IQuotationDocumentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-pdf-form-fields")]
        public async Task<IActionResult> OpenPdfFormFieldsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenPdfFormFieldsAsync(ids);
            return Ok(result);
        }
    }
    
}