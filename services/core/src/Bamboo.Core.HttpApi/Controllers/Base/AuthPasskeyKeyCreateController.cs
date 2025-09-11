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
    // Category: Hidden/Tools, Module: auth_passkey
    [Authorize]
    [Route("api/v1/auth-passkey/AuthPasskeyKeyCreate")]
    public partial class AuthPasskeyKeyCreateController : AbpController
    {
        private readonly IAuthPasskeyKeyCreateAppService _appService;
        public AuthPasskeyKeyCreateController(IAuthPasskeyKeyCreateAppService appService) { _appService = appService; }
    }
}