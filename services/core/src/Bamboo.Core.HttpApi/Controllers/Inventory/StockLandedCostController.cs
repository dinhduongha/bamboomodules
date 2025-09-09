using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    [Route("api/v1/inventory/StockLandedCost")]
    public partial class StockLandedCostController : AbpController
    {
        private readonly IStockLandedCostAppService _appService;
        public StockLandedCostController(IStockLandedCostAppService appService) { _appService = appService; }
    }
}