using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrDefault")]
    public partial class IrDefaultController : AbpController
    {
        private readonly IIrDefaultAppService _appService;
        public IrDefaultController(IIrDefaultAppService appService) { _appService = appService; }
    }
}