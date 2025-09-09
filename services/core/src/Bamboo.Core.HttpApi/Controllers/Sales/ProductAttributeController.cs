using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductAttribute")]
    public partial class ProductAttributeController : AbpController
    {
        private readonly IProductAttributeAppService _appService;
        public ProductAttributeController(IProductAttributeAppService appService) { _appService = appService; }
    }
}