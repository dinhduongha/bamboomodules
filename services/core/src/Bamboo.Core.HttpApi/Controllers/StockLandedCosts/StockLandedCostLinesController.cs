using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    [Route("api/v1/inventory/StockLandedCostLines")]
    public partial class StockLandedCostLinesController : AbpControllerBase
    {
        private readonly IStockLandedCostLinesAppService _appService;
        public StockLandedCostLinesController(IStockLandedCostLinesAppService appService) { _appService = appService; }
    }
}