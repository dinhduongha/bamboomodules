using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseAutomationModule
{
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpControllerBase
    {
        private readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
    }
}