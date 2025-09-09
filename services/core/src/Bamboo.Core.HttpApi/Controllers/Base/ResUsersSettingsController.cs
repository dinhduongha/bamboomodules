using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResUsersSettings")]
    public partial class ResUsersSettingsController : AbpController
    {
        private readonly IResUsersSettingsAppService _appService;
        public ResUsersSettingsController(IResUsersSettingsAppService appService) { _appService = appService; }
    }
}