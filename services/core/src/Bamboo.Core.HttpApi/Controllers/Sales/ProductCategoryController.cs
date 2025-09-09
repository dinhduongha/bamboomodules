using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductCategory")]
    public partial class ProductCategoryController : AbpController
    {
        private readonly IProductCategoryAppService _appService;
        public ProductCategoryController(IProductCategoryAppService appService) { _appService = appService; }
    }
}