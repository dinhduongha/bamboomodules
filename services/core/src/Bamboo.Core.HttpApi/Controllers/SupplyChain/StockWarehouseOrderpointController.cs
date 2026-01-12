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
    // Category: Supply Chain/Inventory, Module: stock
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockWarehouseOrderpoint")]
    public partial class StockWarehouseOrderpointController : AbpController
    {
        private readonly IStockWarehouseOrderpointAppService _appService;
        public StockWarehouseOrderpointController(IStockWarehouseOrderpointAppService appService) { _appService = appService; }
    }
}