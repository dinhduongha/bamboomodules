using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    [Route("api/v1/auth-passkey/AuthPasskeyKey")]
    public partial class AuthPasskeyKeyController : AbpControllerBase
    {
        private readonly IAuthPasskeyKeyAppService _appService;
        public AuthPasskeyKeyController(IAuthPasskeyKeyAppService appService) { _appService = appService; }
    }
}