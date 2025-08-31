using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductAttributeValue")]
    public partial class ProductAttributeValueController : AbpControllerBase
    {
        private readonly IProductAttributeValueAppService _appService;
        public ProductAttributeValueController(IProductAttributeValueAppService appService) { _appService = appService; }
    }
}