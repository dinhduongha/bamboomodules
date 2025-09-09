using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    [Route("api/v1/auth-passkey/AuthPasskeyKey")]
    public partial class AuthPasskeyKeyController : AbpController
    {
        private readonly IAuthPasskeyKeyAppService _appService;
        public AuthPasskeyKeyController(IAuthPasskeyKeyAppService appService) { _appService = appService; }
    }
}