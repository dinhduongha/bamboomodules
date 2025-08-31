using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    [Route("api/v1/sms/SmsTemplate")]
    public partial class SmsTemplateController : AbpControllerBase
    {
        private readonly ISmsTemplateAppService _appService;
        public SmsTemplateController(ISmsTemplateAppService appService) { _appService = appService; }
    }
}