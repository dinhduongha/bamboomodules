using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountBudget
{
    [Route("api/v1/accounting/CrossoveredBudgetLines")]
    public partial class CrossoveredBudgetLinesController : AbpControllerBase
    {
        private readonly ICrossoveredBudgetLinesAppService _appService;
        public CrossoveredBudgetLinesController(ICrossoveredBudgetLinesAppService appService) { _appService = appService; }
    }
}