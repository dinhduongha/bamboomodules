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
    [Route("api/v1/base/BaseEnableProfilingWizard")]
    public partial class BaseEnableProfilingWizardController : AbpController
    {
        private readonly IBaseEnableProfilingWizardAppService _appService;
        public BaseEnableProfilingWizardController(IBaseEnableProfilingWizardAppService appService) { _appService = appService; }
    }
}