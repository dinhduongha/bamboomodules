using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Productivity/Discuss, Module: mail
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/MailPushDevice")]
    public partial class MailPushDeviceController : AbpController
    {
        private readonly IMailPushDeviceAppService _appService;
        public MailPushDeviceController(IMailPushDeviceAppService appService) { _appService = appService; }
    }
}