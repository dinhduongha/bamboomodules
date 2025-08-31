using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessageSchedule")]
    public partial class MailMessageScheduleController : AbpControllerBase
    {
        private readonly IMailMessageScheduleAppService _appService;
        public MailMessageScheduleController(IMailMessageScheduleAppService appService) { _appService = appService; }
    }
}