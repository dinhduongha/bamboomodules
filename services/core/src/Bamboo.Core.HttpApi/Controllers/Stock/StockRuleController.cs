using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockRule")]
    public partial class StockRuleController : AbpControllerBase
    {
        private readonly IStockRuleAppService _appService;
        public StockRuleController(IStockRuleAppService appService) { _appService = appService; }
    }
}