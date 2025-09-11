using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: , Module: mail_group
    [Authorize]
    [Route("api/v1/MailGroupMessage")]
    public partial class MailGroupMessageController : AbpController
    {
        private readonly IMailGroupMessageAppService _appService;
        public MailGroupMessageController(IMailGroupMessageAppService appService) { _appService = appService; }
    }
}