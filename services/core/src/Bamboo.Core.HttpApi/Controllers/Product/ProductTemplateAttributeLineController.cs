using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTemplateAttributeLine")]
    public partial class ProductTemplateAttributeLineController : AbpControllerBase
    {
        private readonly IProductTemplateAttributeLineAppService _appService;
        public ProductTemplateAttributeLineController(IProductTemplateAttributeLineAppService appService) { _appService = appService; }
    }
}