using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTemplateAttributeLine")]
    public partial class ProductTemplateAttributeLineController : AbpController
    {
        private readonly IProductTemplateAttributeLineAppService _appService;
        public ProductTemplateAttributeLineController(IProductTemplateAttributeLineAppService appService) { _appService = appService; }
    }
}