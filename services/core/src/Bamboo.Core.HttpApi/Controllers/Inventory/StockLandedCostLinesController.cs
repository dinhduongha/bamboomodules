using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    [Route("api/v1/inventory/StockLandedCostLines")]
    public partial class StockLandedCostLinesController : AbpController
    {
        private readonly IStockLandedCostLinesAppService _appService;
        public StockLandedCostLinesController(IStockLandedCostLinesAppService appService) { _appService = appService; }
    }
}