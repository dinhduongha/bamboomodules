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
    [Route("api/v1/marketing/MailingList")]
    public partial class MailingListController : AbpController
    {
        private readonly IMailingListAppService _appService;
        public MailingListController(IMailingListAppService appService) { _appService = appService; }
    }
}