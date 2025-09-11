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
    // Category: Accounting, Module: om_recurring_payments
    [Authorize]
    [Route("api/v1/accounting/AccountRecurringTemplate")]
    public partial class AccountRecurringTemplateController : AbpController
    {
        private readonly IAccountRecurringTemplateAppService _appService;
        public AccountRecurringTemplateController(IAccountRecurringTemplateAppService appService) { _appService = appService; }
    }
}