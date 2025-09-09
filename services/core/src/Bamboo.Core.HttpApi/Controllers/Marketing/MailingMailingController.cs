using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingMailing")]
    public partial class MailingMailingController : AbpController
    {
        private readonly IMailingMailingAppService _appService;
        public MailingMailingController(IMailingMailingAppService appService) { _appService = appService; }
    }
}