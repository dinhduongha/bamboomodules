using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductPricelist")]
    public partial class ProductPricelistController : AbpController
    {
        private readonly IProductPricelistAppService _appService;
        public ProductPricelistController(IProductPricelistAppService appService) { _appService = appService; }
    }
}