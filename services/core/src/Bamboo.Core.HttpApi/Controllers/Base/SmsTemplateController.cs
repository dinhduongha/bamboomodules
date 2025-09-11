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
    [Route("api/v1/sms/SmsTemplate")]
    public partial class SmsTemplateController : AbpController
    {
        private readonly ISmsTemplateAppService _appService;
        public SmsTemplateController(ISmsTemplateAppService appService) { _appService = appService; }
    }
}