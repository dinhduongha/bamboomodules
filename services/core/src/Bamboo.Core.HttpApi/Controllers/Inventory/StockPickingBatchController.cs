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
    // Category: Inventory/Inventory, Module: stock_picking_batch
    [Authorize]
    [Route("api/v1/inventory/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpController
    {
        private readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
    }
}