using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailActivity")]
    public partial class MailActivityController : AbpController
    {
        private readonly IMailActivityAppService _appService;
        public MailActivityController(IMailActivityAppService appService) { _appService = appService; }
    }
}