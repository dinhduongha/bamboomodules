using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticPlan")]
    public partial class AccountAnalyticPlanController : AbpControllerBase
    {
        private readonly IAccountAnalyticPlanAppService _appService;
        public AccountAnalyticPlanController(IAccountAnalyticPlanAppService appService) { _appService = appService; }
    }
}