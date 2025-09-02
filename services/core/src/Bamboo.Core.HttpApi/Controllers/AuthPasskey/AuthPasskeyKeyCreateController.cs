using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    [Route("api/v1/auth-passkey/AuthPasskeyKeyCreate")]
    public partial class AuthPasskeyKeyCreateController : AbpControllerBase
    {
        private readonly IAuthPasskeyKeyCreateAppService _appService;
        public AuthPasskeyKeyCreateController(IAuthPasskeyKeyCreateAppService appService) { _appService = appService; }
    }
}