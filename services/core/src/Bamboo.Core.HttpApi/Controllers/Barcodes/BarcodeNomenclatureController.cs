using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Barcodes
{
    [Route("api/v1/barcodes/BarcodeNomenclature")]
    public partial class BarcodeNomenclatureController : AbpControllerBase
    {
        private readonly IBarcodeNomenclatureAppService _appService;
        public BarcodeNomenclatureController(IBarcodeNomenclatureAppService appService) { _appService = appService; }
    }
}