using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: stock_account
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/stock-account/StockValuationLayer")]
    public partial class StockValuationLayerController : AbpController
    {
        private readonly IStockValuationLayerAppService _appService;
        public StockValuationLayerController(IStockValuationLayerAppService appService) { _appService = appService; }
    }
}