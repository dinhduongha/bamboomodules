using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailPushDevice")]
    public partial class MailPushDeviceController : AbpControllerBase
    {
        private readonly IMailPushDeviceAppService _appService;
        public MailPushDeviceController(IMailPushDeviceAppService appService) { _appService = appService; }
    }
}