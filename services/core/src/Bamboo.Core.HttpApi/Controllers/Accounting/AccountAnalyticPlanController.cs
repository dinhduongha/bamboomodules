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
    // Category: Accounting/Accounting, Module: analytic
    [Authorize]
    [Route("api/v1/accounting/AccountAnalyticPlan")]
    public partial class AccountAnalyticPlanController : AbpController
    {
        private readonly IAccountAnalyticPlanAppService _appService;
        public AccountAnalyticPlanController(IAccountAnalyticPlanAppService appService) { _appService = appService; }
    }
}