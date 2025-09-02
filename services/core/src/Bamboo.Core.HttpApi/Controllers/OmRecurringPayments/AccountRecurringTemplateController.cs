using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/AccountRecurringTemplate")]
    public partial class AccountRecurringTemplateController : AbpControllerBase
    {
        private readonly IAccountRecurringTemplateAppService _appService;
        public AccountRecurringTemplateController(IAccountRecurringTemplateAppService appService) { _appService = appService; }
    }
}