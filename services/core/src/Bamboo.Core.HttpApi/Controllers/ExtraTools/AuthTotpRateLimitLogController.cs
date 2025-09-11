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
    // Category: Extra Tools, Module: auth_totp_mail_enforce
    [Authorize]
    [Route("api/v1/extra-tools/AuthTotpRateLimitLog")]
    public partial class AuthTotpRateLimitLogController : AbpController
    {
        private readonly IAuthTotpRateLimitLogAppService _appService;
        public AuthTotpRateLimitLogController(IAuthTotpRateLimitLogAppService appService) { _appService = appService; }
    }
}