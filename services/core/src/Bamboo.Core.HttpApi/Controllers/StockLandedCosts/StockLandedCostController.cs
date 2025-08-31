using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    [Route("api/v1/inventory/StockLandedCost")]
    public partial class StockLandedCostController : AbpControllerBase
    {
        private readonly IStockLandedCostAppService _appService;
        public StockLandedCostController(IStockLandedCostAppService appService) { _appService = appService; }
    }
}