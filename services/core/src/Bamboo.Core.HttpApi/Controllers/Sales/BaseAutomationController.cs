using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseAutomationModule
{
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpController
    {
        private readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
    }
}