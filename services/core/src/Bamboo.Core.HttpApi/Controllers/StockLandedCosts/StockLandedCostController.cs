using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    [Route("api/v1/inventory/StockLandedCost")]
    public partial class StockLandedCostController : AbpControllerBase
    {
        private readonly IStockLandedCostAppService _appService;
        public StockLandedCostController(IStockLandedCostAppService appService) { _appService = appService; }
    }
}