using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    [Route("api/v1/auth-passkey/AuthPasskeyKey")]
    public partial class AuthPasskeyKeyController : AbpControllerBase
    {
        private readonly IAuthPasskeyKeyAppService _appService;
        public AuthPasskeyKeyController(IAuthPasskeyKeyAppService appService) { _appService = appService; }
    }
}