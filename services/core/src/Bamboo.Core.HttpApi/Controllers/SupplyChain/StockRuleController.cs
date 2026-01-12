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
    // Category: Inventory/Inventory, Module: stock
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/inventory/StockRule")]
    public partial class StockRuleController : AbpController
    {
        private readonly IStockRuleAppService _appService;
        public StockRuleController(IStockRuleAppService appService) { _appService = appService; }
    }
}