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
    // Category: Productivity/Discuss, Module: mail
    [Authorize]
    [Route("api/v1/productivity/MailMessageTranslation")]
    public partial class MailMessageTranslationController : AbpController
    {
        private readonly IMailMessageTranslationAppService _appService;
        public MailMessageTranslationController(IMailMessageTranslationAppService appService) { _appService = appService; }
    }
}