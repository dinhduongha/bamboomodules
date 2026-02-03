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
    // Category: Hidden/Tools, Module: sms_twilio
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sms-twilio/SmsTwilioNumber")]
    public partial class SmsTwilioNumberController : AbpController
    {
        private readonly ISmsTwilioNumberAppService _appService;
        public SmsTwilioNumberController(ISmsTwilioNumberAppService appService) { _appService = appService; }
    }
}