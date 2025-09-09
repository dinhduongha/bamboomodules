using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.StockPickingBatchModule
{
    [Route("api/v1/inventory/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpController
    {
        private readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
    }
}