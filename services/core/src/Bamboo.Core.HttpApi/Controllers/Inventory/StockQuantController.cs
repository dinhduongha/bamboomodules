using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockQuant")]
    public partial class StockQuantController : AbpController
    {
        private readonly IStockQuantAppService _appService;
        public StockQuantController(IStockQuantAppService appService) { _appService = appService; }
    }
}