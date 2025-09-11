using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: stock_account
    [Authorize]
    [Route("api/v1/stock-account/StockValuationLayer")]
    public partial class StockValuationLayerController : AbpController
    {
        private readonly IStockValuationLayerAppService _appService;
        public StockValuationLayerController(IStockValuationLayerAppService appService) { _appService = appService; }
    }
}