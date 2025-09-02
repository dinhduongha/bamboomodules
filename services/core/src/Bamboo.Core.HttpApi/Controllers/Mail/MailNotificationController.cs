using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailNotification")]
    public partial class MailNotificationController : AbpControllerBase
    {
        private readonly IMailNotificationAppService _appService;
        public MailNotificationController(IMailNotificationAppService appService) { _appService = appService; }
    }
}