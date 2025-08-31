using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockMove")]
    public partial class StockMoveController : AbpControllerBase
    {
        private readonly IStockMoveAppService _appService;
        public StockMoveController(IStockMoveAppService appService) { _appService = appService; }
    }
}