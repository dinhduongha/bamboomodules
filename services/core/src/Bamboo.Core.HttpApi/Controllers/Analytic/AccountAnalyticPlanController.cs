using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticPlan")]
    public partial class AccountAnalyticPlanController : AbpControllerBase
    {
        private readonly IAccountAnalyticPlanAppService _appService;
        public AccountAnalyticPlanController(IAccountAnalyticPlanAppService appService) { _appService = appService; }
    }
}