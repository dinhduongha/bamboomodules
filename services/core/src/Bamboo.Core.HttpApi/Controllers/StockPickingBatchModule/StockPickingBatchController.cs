using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockPickingBatchModule
{
    [Route("api/v1/inventory/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpControllerBase
    {
        private readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
    }
}