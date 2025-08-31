using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    [Route("api/v1/marketing/MailingList")]
    public partial class MailingListController : AbpControllerBase
    {
        private readonly IMailingListAppService _appService;
        public MailingListController(IMailingListAppService appService) { _appService = appService; }
    }
}