using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessage")]
    public partial class MailMessageController : AbpControllerBase
    {
        private readonly IMailMessageAppService _appService;
        public MailMessageController(IMailMessageAppService appService) { _appService = appService; }
    }
}