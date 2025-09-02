using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductAttributeValue")]
    public partial class ProductAttributeValueController : AbpControllerBase
    {
        private readonly IProductAttributeValueAppService _appService;
        public ProductAttributeValueController(IProductAttributeValueAppService appService) { _appService = appService; }
    }
}