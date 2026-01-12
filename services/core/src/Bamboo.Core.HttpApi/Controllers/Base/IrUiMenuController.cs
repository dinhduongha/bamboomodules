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
    [Route("api/v1/base/IrUiMenu")]
    public partial class IrUiMenuController : AbpController
    {
        private readonly IIrUiMenuAppService _appService;
        public IrUiMenuController(IIrUiMenuAppService appService) { _appService = appService; }
    }
}