using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMail")]
    public partial class MailMailController : AbpControllerBase
    {
        private readonly IMailMailAppService _appService;
        public MailMailController(IMailMailAppService appService) { _appService = appService; }
    }
}