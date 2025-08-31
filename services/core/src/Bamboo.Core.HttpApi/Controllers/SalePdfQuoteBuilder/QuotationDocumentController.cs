using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SalePdfQuoteBuilder
{
    [Route("api/v1/sales/QuotationDocument")]
    public partial class QuotationDocumentController : AbpControllerBase
    {
        private readonly IQuotationDocumentAppService _appService;
        public QuotationDocumentController(IQuotationDocumentAppService appService) { _appService = appService; }
    }
}