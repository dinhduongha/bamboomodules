using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: sale_management
    [Authorize]
    [Route("api/v1/sales/SaleOrderOption")]
    public partial class SaleOrderOptionController : AbpController
    {
        private readonly ISaleOrderOptionAppService _appService;
        public SaleOrderOptionController(ISaleOrderOptionAppService appService) { _appService = appService; }
    }
}