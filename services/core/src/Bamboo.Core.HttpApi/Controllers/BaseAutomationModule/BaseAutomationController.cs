using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseAutomationModule
{
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpControllerBase
    {
        private readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
    }
}