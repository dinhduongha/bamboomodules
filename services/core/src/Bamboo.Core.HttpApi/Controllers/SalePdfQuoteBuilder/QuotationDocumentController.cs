using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SalePdfQuoteBuilder
{
    [Route("api/v1/sales/QuotationDocument")]
    public partial class QuotationDocumentController : AbpControllerBase
    {
        private readonly IQuotationDocumentAppService _appService;
        public QuotationDocumentController(IQuotationDocumentAppService appService) { _appService = appService; }
    }
}