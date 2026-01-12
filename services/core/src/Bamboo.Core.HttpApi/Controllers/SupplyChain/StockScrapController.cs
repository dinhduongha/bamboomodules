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
    [Route("api/v1/inventory/StockScrap")]
    public partial class StockScrapController : AbpController
    {
        private readonly IStockScrapAppService _appService;
        public StockScrapController(IStockScrapAppService appService) { _appService = appService; }
    }
}