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
    // Category: Hidden/Tools, Module: auth_passkey
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/auth-passkey/AuthPasskeyKeyCreate")]
    public partial class AuthPasskeyKeyCreateController : AbpController
    {
        private readonly IAuthPasskeyKeyCreateAppService _appService;
        public AuthPasskeyKeyCreateController(IAuthPasskeyKeyCreateAppService appService) { _appService = appService; }
    }
}