using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailTrackingValue")]
    public partial class MailTrackingValueController : AbpControllerBase
    {
        private readonly IMailTrackingValueAppService _appService;
        public MailTrackingValueController(IMailTrackingValueAppService appService) { _appService = appService; }
    }
}