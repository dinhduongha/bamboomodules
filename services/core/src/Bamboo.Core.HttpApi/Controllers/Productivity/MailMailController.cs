using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMail")]
    public partial class MailMailController : AbpController
    {
        private readonly IMailMailAppService _appService;
        public MailMailController(IMailMailAppService appService) { _appService = appService; }
    }
}