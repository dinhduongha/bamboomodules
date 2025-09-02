using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PhoneValidation
{
    [Route("api/v1/phone-validation/PhoneBlacklist")]
    public partial class PhoneBlacklistController : AbpControllerBase
    {
        private readonly IPhoneBlacklistAppService _appService;
        public PhoneBlacklistController(IPhoneBlacklistAppService appService) { _appService = appService; }
    }
}