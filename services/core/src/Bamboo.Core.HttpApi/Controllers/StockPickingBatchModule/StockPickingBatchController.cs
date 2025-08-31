using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockPickingBatchModule
{
    [Route("api/v1/inventory/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpControllerBase
    {
        private readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
    }
}