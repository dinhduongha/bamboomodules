using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockRoute")]
    public partial class StockRouteController : AbpControllerBase
    {
        private readonly IStockRouteAppService _appService;
        public StockRouteController(IStockRouteAppService appService) { _appService = appService; }
    }
}