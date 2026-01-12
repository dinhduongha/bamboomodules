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
    [Route("api/v1/accounting/RecurringPaymentLine")]
    public partial class RecurringPaymentLineController : AbpController
    {
        private readonly IRecurringPaymentLineAppService _appService;
        public RecurringPaymentLineController(IRecurringPaymentLineAppService appService) { _appService = appService; }
    }
}