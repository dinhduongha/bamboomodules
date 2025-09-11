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
    // Category: Sales/Sales, Module: base_automation
    [Authorize]
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpController
    {
        private readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
    }
}