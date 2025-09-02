using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingSubscription")]
    public partial class MailingSubscriptionController : AbpControllerBase
    {
        private readonly IMailingSubscriptionAppService _appService;
        public MailingSubscriptionController(IMailingSubscriptionAppService appService) { _appService = appService; }
    }
}