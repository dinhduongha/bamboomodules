using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductProduct")]
    public partial class ProductProductController : AbpControllerBase
    {
        private readonly IProductProductAppService _appService;
        public ProductProductController(IProductProductAppService appService) { _appService = appService; }
    }
}