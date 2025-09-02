using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductPricelist")]
    public partial class ProductPricelistController : AbpControllerBase
    {
        private readonly IProductPricelistAppService _appService;
        public ProductPricelistController(IProductPricelistAppService appService) { _appService = appService; }
    }
}