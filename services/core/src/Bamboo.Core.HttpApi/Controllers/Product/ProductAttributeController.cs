using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductAttribute")]
    public partial class ProductAttributeController : AbpControllerBase
    {
        private readonly IProductAttributeAppService _appService;
        public ProductAttributeController(IProductAttributeAppService appService) { _appService = appService; }
    }
}