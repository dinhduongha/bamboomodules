using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTag")]
    public partial class ProductTagController : AbpControllerBase
    {
        private readonly IProductTagAppService _appService;
        public ProductTagController(IProductTagAppService appService) { _appService = appService; }
    }
}