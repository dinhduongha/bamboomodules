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
    // Category: Hidden, Module: phone_validation
    [Authorize]
    [Route("api/v1/phone-validation/PhoneBlacklist")]
    public partial class PhoneBlacklistController : AbpController
    {
        private readonly IPhoneBlacklistAppService _appService;
        public PhoneBlacklistController(IPhoneBlacklistAppService appService) { _appService = appService; }
    }
}