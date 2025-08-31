using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailNotification")]
    public partial class MailNotificationController : AbpControllerBase
    {
        private readonly IMailNotificationAppService _appService;
        public MailNotificationController(IMailNotificationAppService appService) { _appService = appService; }
    }
}