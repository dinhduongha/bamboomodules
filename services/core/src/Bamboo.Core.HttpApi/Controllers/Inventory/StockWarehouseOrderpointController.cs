using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockWarehouseOrderpoint")]
    public partial class StockWarehouseOrderpointController : AbpController
    {
        private readonly IStockWarehouseOrderpointAppService _appService;
        public StockWarehouseOrderpointController(IStockWarehouseOrderpointAppService appService) { _appService = appService; }
    }
}