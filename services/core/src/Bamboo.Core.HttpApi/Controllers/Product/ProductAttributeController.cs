using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductAttribute")]
    public partial class ProductAttributeController : AbpControllerBase
    {
        private readonly IProductAttributeAppService _appService;
        public ProductAttributeController(IProductAttributeAppService appService) { _appService = appService; }
    }
}