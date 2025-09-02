using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingTrace")]
    public partial class MailingTraceController : AbpControllerBase
    {
        private readonly IMailingTraceAppService _appService;
        public MailingTraceController(IMailingTraceAppService appService) { _appService = appService; }
    }
}