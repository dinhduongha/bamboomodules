using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrModelData")]
    public partial class IrModelDataController : AbpControllerBase
    {
        private readonly IIrModelDataAppService _appService;
        public IrModelDataController(IIrModelDataAppService appService) { _appService = appService; }
    }
}