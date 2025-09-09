using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Barcodes
{
    [Route("api/v1/barcodes/BarcodeNomenclature")]
    public partial class BarcodeNomenclatureController : AbpController
    {
        private readonly IBarcodeNomenclatureAppService _appService;
        public BarcodeNomenclatureController(IBarcodeNomenclatureAppService appService) { _appService = appService; }
    }
}