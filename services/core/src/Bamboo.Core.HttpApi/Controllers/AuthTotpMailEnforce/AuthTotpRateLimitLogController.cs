using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotpMailEnforce
{
    [Route("api/v1/extra-tools/AuthTotpRateLimitLog")]
    public partial class AuthTotpRateLimitLogController : AbpControllerBase
    {
        private readonly IAuthTotpRateLimitLogAppService _appService;
        public AuthTotpRateLimitLogController(IAuthTotpRateLimitLogAppService appService) { _appService = appService; }
    }
}