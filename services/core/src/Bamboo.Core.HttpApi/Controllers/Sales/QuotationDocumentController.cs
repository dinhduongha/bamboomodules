using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: sale_pdf_quote_builder
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/QuotationDocument")]
    public partial class QuotationDocumentController : AbpController
    {
        private readonly IQuotationDocumentAppService _appService;
        public QuotationDocumentController(IQuotationDocumentAppService appService) { _appService = appService; }
    }
}