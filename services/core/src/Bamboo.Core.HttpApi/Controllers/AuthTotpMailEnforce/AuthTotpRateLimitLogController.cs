using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotpMailEnforce
{
    [Route("api/v1/extra-tools/AuthTotpRateLimitLog")]
    public partial class AuthTotpRateLimitLogController : AbpControllerBase
    {
        private readonly IAuthTotpRateLimitLogAppService _appService;
        public AuthTotpRateLimitLogController(IAuthTotpRateLimitLogAppService appService) { _appService = appService; }
    }
}