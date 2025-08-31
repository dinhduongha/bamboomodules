using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrConfigParameter")]
    public partial class IrConfigParameterController : AbpControllerBase
    {
        private readonly IIrConfigParameterAppService _appService;
        public IrConfigParameterController(IIrConfigParameterAppService appService) { _appService = appService; }
    }
}