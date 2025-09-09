using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockMoveLine")]
    public partial class StockMoveLineController : AbpController
    {
        private readonly IStockMoveLineAppService _appService;
        public StockMoveLineController(IStockMoveLineAppService appService) { _appService = appService; }
    }
}