using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTemplate")]
    public partial class ProductTemplateController : AbpControllerBase
    {
        private readonly IProductTemplateAppService _appService;
        public ProductTemplateController(IProductTemplateAppService appService) { _appService = appService; }
    }
}