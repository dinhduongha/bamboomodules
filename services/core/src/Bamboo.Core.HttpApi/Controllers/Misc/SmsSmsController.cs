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
    // Category: Hidden/Tools, Module: sms
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sms/SmsSms")]
    public partial class SmsSmsController : AbpController
    {
        private readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
    }
}