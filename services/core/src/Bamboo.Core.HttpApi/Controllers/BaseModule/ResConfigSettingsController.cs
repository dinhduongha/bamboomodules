using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResConfigSettings")]
    public partial class ResConfigSettingsController : AbpControllerBase
    {
        private readonly IResConfigSettingsAppService _appService;
        public ResConfigSettingsController(IResConfigSettingsAppService appService) { _appService = appService; }
    }
}