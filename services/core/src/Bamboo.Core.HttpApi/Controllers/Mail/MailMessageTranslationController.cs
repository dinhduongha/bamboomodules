using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessageTranslation")]
    public partial class MailMessageTranslationController : AbpControllerBase
    {
        private readonly IMailMessageTranslationAppService _appService;
        public MailMessageTranslationController(IMailMessageTranslationAppService appService) { _appService = appService; }
    }
}