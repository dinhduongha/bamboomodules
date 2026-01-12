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
    // Category: Productivity/Discuss, Module: mail
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/ResUsersSettingsVolumes")]
    public partial class ResUsersSettingsVolumesController : AbpController
    {
        private readonly IResUsersSettingsVolumesAppService _appService;
        public ResUsersSettingsVolumesController(IResUsersSettingsVolumesAppService appService) { _appService = appService; }
    }
}