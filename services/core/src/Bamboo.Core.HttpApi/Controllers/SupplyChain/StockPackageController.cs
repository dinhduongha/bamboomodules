using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Supply Chain/Inventory, Module: stock
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockPackage")]
    public partial class StockPackageController : AbpController
    {
        private readonly IStockPackageAppService _appService;
        public StockPackageController(IStockPackageAppService appService) { _appService = appService; }
    }
}