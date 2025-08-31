using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockQuantPackage")]
    public partial class StockQuantPackageController : AbpControllerBase
    {
        private readonly IStockQuantPackageAppService _appService;
        public StockQuantPackageController(IStockQuantPackageAppService appService) { _appService = appService; }
    }
}