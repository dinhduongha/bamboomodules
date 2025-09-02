using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/MailActivityPlan")]
    public partial class MailActivityPlanController : AbpControllerBase
    {
        private readonly IMailActivityPlanAppService _appService;
        public MailActivityPlanController(IMailActivityPlanAppService appService) { _appService = appService; }
    }
}