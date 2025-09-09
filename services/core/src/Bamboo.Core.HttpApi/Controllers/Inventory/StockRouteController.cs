using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockRoute")]
    public partial class StockRouteController : AbpController
    {
        private readonly IStockRouteAppService _appService;
        public StockRouteController(IStockRouteAppService appService) { _appService = appService; }
    }
}