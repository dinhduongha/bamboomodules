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
    // Category: , Module: mail_group
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/MailGroupMessage")]
    public partial class MailGroupMessageController : AbpController
    {
        private readonly IMailGroupMessageAppService _appService;
        public MailGroupMessageController(IMailGroupMessageAppService appService) { _appService = appService; }
    }
}