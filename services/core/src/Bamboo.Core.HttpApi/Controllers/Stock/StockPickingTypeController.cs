using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockPickingType")]
    public partial class StockPickingTypeController : AbpControllerBase
    {
        private readonly IStockPickingTypeAppService _appService;
        public StockPickingTypeController(IStockPickingTypeAppService appService) { _appService = appService; }
    }
}