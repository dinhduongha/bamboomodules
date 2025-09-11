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
    // Category: Sales/Sales, Module: product
    [Authorize]
    [Route("api/v1/sales/ProductTemplate")]
    public partial class ProductTemplateController : AbpController
    {
        private readonly IProductTemplateAppService _appService;
        public ProductTemplateController(IProductTemplateAppService appService) { _appService = appService; }
    }
}