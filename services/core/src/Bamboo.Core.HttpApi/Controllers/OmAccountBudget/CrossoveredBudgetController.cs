using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountBudget
{
    [Route("api/v1/accounting/CrossoveredBudget")]
    public partial class CrossoveredBudgetController : AbpControllerBase
    {
        private readonly ICrossoveredBudgetAppService _appService;
        public CrossoveredBudgetController(ICrossoveredBudgetAppService appService) { _appService = appService; }
    }
}