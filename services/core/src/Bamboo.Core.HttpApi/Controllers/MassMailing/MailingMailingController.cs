using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingMailing")]
    public partial class MailingMailingController : AbpControllerBase
    {
        private readonly IMailingMailingAppService _appService;
        public MailingMailingController(IMailingMailingAppService appService) { _appService = appService; }
    }
}