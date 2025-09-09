using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResConfigSettings")]
    public partial class ResConfigSettingsController : AbpController
    {
        private readonly IResConfigSettingsAppService _appService;
        public ResConfigSettingsController(IResConfigSettingsAppService appService) { _appService = appService; }
    }
}