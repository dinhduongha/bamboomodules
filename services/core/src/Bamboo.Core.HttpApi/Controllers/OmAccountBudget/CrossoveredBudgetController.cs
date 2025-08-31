using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountBudget
{
    [Route("api/v1/accounting/CrossoveredBudget")]
    public partial class CrossoveredBudgetController : AbpControllerBase
    {
        private readonly ICrossoveredBudgetAppService _appService;
        public CrossoveredBudgetController(ICrossoveredBudgetAppService appService) { _appService = appService; }
    }
}