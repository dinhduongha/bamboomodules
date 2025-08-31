using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Barcodes
{
    [Route("api/v1/barcodes/BarcodeNomenclature")]
    public partial class BarcodeNomenclatureController : AbpControllerBase
    {
        private readonly IBarcodeNomenclatureAppService _appService;
        public BarcodeNomenclatureController(IBarcodeNomenclatureAppService appService) { _appService = appService; }
    }
}