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
    // Category: Hidden/Tools, Module: sms
    [Authorize]
    [Route("api/v1/sms/SmsSms")]
    public partial class SmsSmsController : AbpController
    {
        private readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
    }
}