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
    // Category: Extra Tools, Module: auth_totp_mail_enforce
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/extra-tools/AuthTotpRateLimitLog")]
    public partial class AuthTotpRateLimitLogController : AbpController
    {
        private readonly IAuthTotpRateLimitLogAppService _appService;
        public AuthTotpRateLimitLogController(IAuthTotpRateLimitLogAppService appService) { _appService = appService; }
    }
}