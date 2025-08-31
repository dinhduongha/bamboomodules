using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductPricelist")]
    public partial class ProductPricelistController : AbpControllerBase
    {
        private readonly IProductPricelistAppService _appService;
        public ProductPricelistController(IProductPricelistAppService appService) { _appService = appService; }
    }
}