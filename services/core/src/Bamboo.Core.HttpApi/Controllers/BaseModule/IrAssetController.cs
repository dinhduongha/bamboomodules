using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrAsset")]
    public partial class IrAssetController : AbpControllerBase
    {
        private readonly IIrAssetAppService _appService;
        public IrAssetController(IIrAssetAppService appService) { _appService = appService; }
    }
}