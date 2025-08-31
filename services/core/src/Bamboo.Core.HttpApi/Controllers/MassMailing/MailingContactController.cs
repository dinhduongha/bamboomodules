using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingContact")]
    public partial class MailingContactController : AbpControllerBase
    {
        private readonly IMailingContactAppService _appService;
        public MailingContactController(IMailingContactAppService appService) { _appService = appService; }
    }
}