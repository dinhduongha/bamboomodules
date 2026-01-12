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
    [Route("api/v1/sales/ProductAttributeValue")]
    public partial class ProductAttributeValueController : AbpController
    {
        private readonly IProductAttributeValueAppService _appService;
        public ProductAttributeValueController(IProductAttributeValueAppService appService) { _appService = appService; }
    }
}