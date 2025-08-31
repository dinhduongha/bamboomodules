using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/StockStorageCategory")]
    public partial class StockStorageCategoryController : AbpControllerBase
    {
        private readonly IStockStorageCategoryAppService _appService;
        public StockStorageCategoryController(IStockStorageCategoryAppService appService) { _appService = appService; }
    }
}