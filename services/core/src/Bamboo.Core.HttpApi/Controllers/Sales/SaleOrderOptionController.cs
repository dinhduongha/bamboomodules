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
    // Category: Sales/Sales, Module: sale_management
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/SaleOrderOption")]
    public partial class SaleOrderOptionController : AbpController
    {
        private readonly ISaleOrderOptionAppService _appService;
        public SaleOrderOptionController(ISaleOrderOptionAppService appService) { _appService = appService; }
    }
}