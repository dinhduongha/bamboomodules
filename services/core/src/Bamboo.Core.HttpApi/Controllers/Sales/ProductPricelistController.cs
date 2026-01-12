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
    [Route("api/v1/sales/ProductPricelist")]
    public partial class ProductPricelistController : AbpController
    {
        private readonly IProductPricelistAppService _appService;
        public ProductPricelistController(IProductPricelistAppService appService) { _appService = appService; }
    }
}