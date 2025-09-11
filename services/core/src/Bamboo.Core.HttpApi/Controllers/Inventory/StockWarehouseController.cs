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
    // Category: Inventory/Inventory, Module: stock
    [Authorize]
    [Route("api/v1/inventory/StockWarehouse")]
    public partial class StockWarehouseController : AbpController
    {
        private readonly IStockWarehouseAppService _appService;
        public StockWarehouseController(IStockWarehouseAppService appService) { _appService = appService; }
    }
}