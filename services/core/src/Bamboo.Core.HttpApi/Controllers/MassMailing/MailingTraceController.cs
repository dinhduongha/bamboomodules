using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingTrace")]
    public partial class MailingTraceController : AbpControllerBase
    {
        private readonly IMailingTraceAppService _appService;
        public MailingTraceController(IMailingTraceAppService appService) { _appService = appService; }
    }
}