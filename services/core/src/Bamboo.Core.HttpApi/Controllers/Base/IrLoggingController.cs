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
    // Category: Hidden, Module: base
    [Authorize]
    [Route("api/v1/base/IrLogging")]
    public partial class IrLoggingController : AbpController
    {
        private readonly IIrLoggingAppService _appService;
        public IrLoggingController(IIrLoggingAppService appService) { _appService = appService; }
    }
}