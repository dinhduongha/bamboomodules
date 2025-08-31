using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockWarehouseOrderpoint")]
    public partial class StockWarehouseOrderpointController : AbpControllerBase
    {
        private readonly IStockWarehouseOrderpointAppService _appService;
        public StockWarehouseOrderpointController(IStockWarehouseOrderpointAppService appService) { _appService = appService; }
    }
}