using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailScheduledMessage")]
    public partial class MailScheduledMessageController : AbpController
    {
        private readonly IMailScheduledMessageAppService _appService;
        public MailScheduledMessageController(IMailScheduledMessageAppService appService) { _appService = appService; }
    }
}