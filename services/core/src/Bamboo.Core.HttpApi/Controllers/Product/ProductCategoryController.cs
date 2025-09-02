using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductCategory")]
    public partial class ProductCategoryController : AbpControllerBase
    {
        private readonly IProductCategoryAppService _appService;
        public ProductCategoryController(IProductCategoryAppService appService) { _appService = appService; }
    }
}