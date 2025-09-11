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
    // Category: Hidden/Tools, Module: iap
    [Authorize]
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpController
    {
        private readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
    }
}