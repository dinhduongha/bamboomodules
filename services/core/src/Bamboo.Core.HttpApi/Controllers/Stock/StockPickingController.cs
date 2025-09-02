using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockPicking")]
    public partial class StockPickingController : AbpControllerBase
    {
        private readonly IStockPickingAppService _appService;
        public StockPickingController(IStockPickingAppService appService) { _appService = appService; }
    }
}