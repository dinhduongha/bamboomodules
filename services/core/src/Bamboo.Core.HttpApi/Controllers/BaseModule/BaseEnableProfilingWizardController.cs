using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/BaseEnableProfilingWizard")]
    public partial class BaseEnableProfilingWizardController : AbpControllerBase
    {
        private readonly IBaseEnableProfilingWizardAppService _appService;
        public BaseEnableProfilingWizardController(IBaseEnableProfilingWizardAppService appService) { _appService = appService; }
    }
}