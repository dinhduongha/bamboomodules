using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockQuantPackage")]
    public partial class StockQuantPackageController : AbpControllerBase
    {
        private readonly IStockQuantPackageAppService _appService;
        public StockQuantPackageController(IStockQuantPackageAppService appService) { _appService = appService; }
    }
}