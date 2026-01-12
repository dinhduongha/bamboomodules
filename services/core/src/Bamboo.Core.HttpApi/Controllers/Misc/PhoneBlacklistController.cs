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
    // Category: Hidden, Module: phone_validation
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/phone-validation/PhoneBlacklist")]
    public partial class PhoneBlacklistController : AbpController
    {
        private readonly IPhoneBlacklistAppService _appService;
        public PhoneBlacklistController(IPhoneBlacklistAppService appService) { _appService = appService; }
    }
}