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
    // Category: Extra Tools, Module: auth_totp
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/extra-tools/AuthTotpDevice")]
    public partial class AuthTotpDeviceController : AbpController
    {
        private readonly IAuthTotpDeviceAppService _appService;
        public AuthTotpDeviceController(IAuthTotpDeviceAppService appService) { _appService = appService; }
    }
}