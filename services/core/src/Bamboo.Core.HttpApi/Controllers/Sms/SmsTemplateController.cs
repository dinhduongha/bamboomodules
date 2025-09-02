using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    [Route("api/v1/sms/SmsTemplate")]
    public partial class SmsTemplateController : AbpControllerBase
    {
        private readonly ISmsTemplateAppService _appService;
        public SmsTemplateController(ISmsTemplateAppService appService) { _appService = appService; }
    }
}