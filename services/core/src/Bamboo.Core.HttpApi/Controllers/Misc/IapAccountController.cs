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
    // Category: Hidden/Tools, Module: iap
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpController
    {
        private readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
    }
}