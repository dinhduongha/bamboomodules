using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockLot")]
    public partial class StockLotController : AbpControllerBase
    {
        private readonly IStockLotAppService _appService;
        public StockLotController(IStockLotAppService appService) { _appService = appService; }
    }
}