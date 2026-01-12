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
    // Category: Supply Chain/Inventory, Module: stock_picking_batch
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpController
    {
        private readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
    }
}