using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockAccount
{
    [Route("api/v1/stock-account/StockValuationLayer")]
    public partial class StockValuationLayerController : AbpController
    {
        private readonly IStockValuationLayerAppService _appService;
        public StockValuationLayerController(IStockValuationLayerAppService appService) { _appService = appService; }
    }
}