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
    // Category: Accounting, Module: om_account_budget
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/CrossoveredBudgetLines")]
    public partial class CrossoveredBudgetLinesController : AbpController
    {
        private readonly ICrossoveredBudgetLinesAppService _appService;
        public CrossoveredBudgetLinesController(ICrossoveredBudgetLinesAppService appService) { _appService = appService; }
    }
}