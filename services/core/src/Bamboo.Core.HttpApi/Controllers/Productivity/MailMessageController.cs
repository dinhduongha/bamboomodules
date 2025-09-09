using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailMessage")]
    public partial class MailMessageController : AbpController
    {
        private readonly IMailMessageAppService _appService;
        public MailMessageController(IMailMessageAppService appService) { _appService = appService; }
    }
}