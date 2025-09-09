using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingContact")]
    public partial class MailingContactController : AbpController
    {
        private readonly IMailingContactAppService _appService;
        public MailingContactController(IMailingContactAppService appService) { _appService = appService; }
    }
}