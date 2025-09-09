using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailActivityType")]
    public partial class MailActivityTypeController : AbpController
    {
        private readonly IMailActivityTypeAppService _appService;
        public MailActivityTypeController(IMailActivityTypeAppService appService) { _appService = appService; }
    }
}