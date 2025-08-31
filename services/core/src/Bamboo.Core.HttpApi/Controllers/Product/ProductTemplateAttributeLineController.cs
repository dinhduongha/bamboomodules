using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTemplateAttributeLine")]
    public partial class ProductTemplateAttributeLineController : AbpControllerBase
    {
        private readonly IProductTemplateAttributeLineAppService _appService;
        public ProductTemplateAttributeLineController(IProductTemplateAttributeLineAppService appService) { _appService = appService; }
    }
}