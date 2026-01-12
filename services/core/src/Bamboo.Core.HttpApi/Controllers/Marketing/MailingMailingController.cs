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
    // Category: Marketing/Email Marketing, Module: mass_mailing
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/MailingMailing")]
    public partial class MailingMailingController : AbpController
    {
        private readonly IMailingMailingAppService _appService;
        public MailingMailingController(IMailingMailingAppService appService) { _appService = appService; }
    }
}