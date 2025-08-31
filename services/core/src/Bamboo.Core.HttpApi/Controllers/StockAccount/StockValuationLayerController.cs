using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockAccount
{
    [Route("api/v1/stock-account/StockValuationLayer")]
    public partial class StockValuationLayerController : AbpControllerBase
    {
        private readonly IStockValuationLayerAppService _appService;
        public StockValuationLayerController(IStockValuationLayerAppService appService) { _appService = appService; }
    }
}