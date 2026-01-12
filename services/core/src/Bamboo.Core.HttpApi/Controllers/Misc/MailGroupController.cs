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
    [Route("api/v1/MailGroup")]
    public partial class MailGroupController : AbpController
    {
        private readonly IMailGroupAppService _appService;
        public MailGroupController(IMailGroupAppService appService) { _appService = appService; }
    }
}