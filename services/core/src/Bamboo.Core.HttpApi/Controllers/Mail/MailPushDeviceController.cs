using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailPushDevice")]
    public partial class MailPushDeviceController : AbpControllerBase
    {
        private readonly IMailPushDeviceAppService _appService;
        public MailPushDeviceController(IMailPushDeviceAppService appService) { _appService = appService; }
    }
}