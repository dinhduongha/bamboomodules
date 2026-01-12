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
    // Category: Hidden, Module: base
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/base/IrModuleModule")]
    public partial class IrModuleModuleController : AbpController
    {
        private readonly IIrModuleModuleAppService _appService;
        public IrModuleModuleController(IIrModuleModuleAppService appService) { _appService = appService; }
    }
}