using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PhoneValidation
{
    [Route("api/v1/phone-validation/PhoneBlacklist")]
    public partial class PhoneBlacklistController : AbpControllerBase
    {
        private readonly IPhoneBlacklistAppService _appService;
        public PhoneBlacklistController(IPhoneBlacklistAppService appService) { _appService = appService; }
    }
}