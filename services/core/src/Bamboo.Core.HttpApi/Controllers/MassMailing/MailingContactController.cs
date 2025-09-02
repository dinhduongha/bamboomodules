using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingContact")]
    public partial class MailingContactController : AbpControllerBase
    {
        private readonly IMailingContactAppService _appService;
        public MailingContactController(IMailingContactAppService appService) { _appService = appService; }
    }
}