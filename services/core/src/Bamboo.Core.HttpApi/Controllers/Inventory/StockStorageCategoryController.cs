using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Inventory/Inventory, Module: stock
    [Authorize]
    [Route("api/v1/inventory/StockStorageCategory")]
    public partial class StockStorageCategoryController : AbpController
    {
        private readonly IStockStorageCategoryAppService _appService;
        public StockStorageCategoryController(IStockStorageCategoryAppService appService) { _appService = appService; }
    }
}