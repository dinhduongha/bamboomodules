using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessageSchedule")]
    public partial class MailMessageScheduleController : AbpController
    {
        private readonly IMailMessageScheduleAppService _appService;
        public MailMessageScheduleController(IMailMessageScheduleAppService appService) { _appService = appService; }
    }
}