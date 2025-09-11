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
    // Category: Marketing/Email Marketing, Module: mass_mailing
    [Authorize]
    [Route("api/v1/marketing/MailingTrace")]
    public partial class MailingTraceController : AbpController
    {
        private readonly IMailingTraceAppService _appService;
        public MailingTraceController(IMailingTraceAppService appService) { _appService = appService; }
    }
}