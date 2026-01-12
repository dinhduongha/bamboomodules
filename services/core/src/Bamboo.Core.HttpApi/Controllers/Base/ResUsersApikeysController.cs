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
    // Category: Hidden, Module: base
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/base/ResUsersApikeys")]
    public partial class ResUsersApikeysController : AbpController
    {
        private readonly IResUsersApikeysAppService _appService;
        public ResUsersApikeysController(IResUsersApikeysAppService appService) { _appService = appService; }
    }
}