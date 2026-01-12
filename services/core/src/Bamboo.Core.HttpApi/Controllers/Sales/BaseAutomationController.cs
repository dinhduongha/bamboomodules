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
    // Category: Sales/Sales, Module: base_automation
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpController
    {
        private readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
    }
}