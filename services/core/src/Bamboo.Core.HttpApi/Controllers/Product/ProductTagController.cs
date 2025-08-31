using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductTag")]
    public partial class ProductTagController : AbpControllerBase
    {
        private readonly IProductTagAppService _appService;
        public ProductTagController(IProductTagAppService appService) { _appService = appService; }
    }
}