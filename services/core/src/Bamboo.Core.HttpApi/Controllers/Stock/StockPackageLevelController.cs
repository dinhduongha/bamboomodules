using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockPackageLevel")]
    public partial class StockPackageLevelController : AbpControllerBase
    {
        private readonly IStockPackageLevelAppService _appService;
        public StockPackageLevelController(IStockPackageLevelAppService appService) { _appService = appService; }
    }
}