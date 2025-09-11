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
    [Route("api/v1/sales/ProductAttributeValue")]
    public partial class ProductAttributeValueController : AbpController
    {
        private readonly IProductAttributeValueAppService _appService;
        public ProductAttributeValueController(IProductAttributeValueAppService appService) { _appService = appService; }
    }
}