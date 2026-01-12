using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting, Module: om_recurring_payments
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountRecurringTemplate")]
    public partial class AccountRecurringTemplateController : AbpController
    {
        private readonly IAccountRecurringTemplateAppService _appService;
        public AccountRecurringTemplateController(IAccountRecurringTemplateAppService appService) { _appService = appService; }
    }
}