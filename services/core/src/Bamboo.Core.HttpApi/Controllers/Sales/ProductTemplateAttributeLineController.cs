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
    // Category: Sales/Sales, Module: product
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/ProductTemplateAttributeLine")]
    public partial class ProductTemplateAttributeLineController : AbpController
    {
        private readonly IProductTemplateAttributeLineAppService _appService;
        public ProductTemplateAttributeLineController(IProductTemplateAttributeLineAppService appService) { _appService = appService; }
    }
}