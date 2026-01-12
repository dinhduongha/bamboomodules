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
    // Category: Supply Chain/Inventory, Module: barcodes
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/BarcodeNomenclature")]
    public partial class BarcodeNomenclatureController : AbpController
    {
        private readonly IBarcodeNomenclatureAppService _appService;
        public BarcodeNomenclatureController(IBarcodeNomenclatureAppService appService) { _appService = appService; }
    }
}