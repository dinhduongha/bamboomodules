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
    [Route("api/v1/sales/ProductSupplierinfo")]
    public partial class ProductSupplierinfoController : AbpController
    {
        private readonly IProductSupplierinfoAppService _appService;
        public ProductSupplierinfoController(IProductSupplierinfoAppService appService) { _appService = appService; }
    }
}