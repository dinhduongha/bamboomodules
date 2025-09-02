using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailTemplate")]
    public partial class MailTemplateController : AbpControllerBase
    {
        private readonly IMailTemplateAppService _appService;
        public MailTemplateController(IMailTemplateAppService appService) { _appService = appService; }
    }
}