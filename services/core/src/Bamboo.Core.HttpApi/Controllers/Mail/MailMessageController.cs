using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessage")]
    public partial class MailMessageController : AbpControllerBase
    {
        private readonly IMailMessageAppService _appService;
        public MailMessageController(IMailMessageAppService appService) { _appService = appService; }
    }
}