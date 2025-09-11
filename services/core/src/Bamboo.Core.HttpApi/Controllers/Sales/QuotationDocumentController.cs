using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: sale_pdf_quote_builder
    [Authorize]
    [Route("api/v1/sales/QuotationDocument")]
    public partial class QuotationDocumentController : AbpController
    {
        private readonly IQuotationDocumentAppService _appService;
        public QuotationDocumentController(IQuotationDocumentAppService appService) { _appService = appService; }
    }
}