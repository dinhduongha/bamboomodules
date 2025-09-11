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
    [Route("api/v1/marketing/MailingSubscription")]
    public partial class MailingSubscriptionController : AbpController
    {
        private readonly IMailingSubscriptionAppService _appService;
        public MailingSubscriptionController(IMailingSubscriptionAppService appService) { _appService = appService; }
    }
}