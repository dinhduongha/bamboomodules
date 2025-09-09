using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockQuantPackage")]
    public partial class StockQuantPackageController : AbpController
    {
        private readonly IStockQuantPackageAppService _appService;
        public StockQuantPackageController(IStockQuantPackageAppService appService) { _appService = appService; }
    }
}