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
    // Category: Accounting, Module: om_account_budget
    [Authorize]
    [Route("api/v1/accounting/CrossoveredBudgetLines")]
    public partial class CrossoveredBudgetLinesController : AbpController
    {
        private readonly ICrossoveredBudgetLinesAppService _appService;
        public CrossoveredBudgetLinesController(ICrossoveredBudgetLinesAppService appService) { _appService = appService; }
    }
}