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
    // Category: Accounting/Accounting, Module: analytic
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountAnalyticLine")]
    public partial class AccountAnalyticLineController : AbpController
    {
        private readonly IAccountAnalyticLineAppService _appService;
        public AccountAnalyticLineController(IAccountAnalyticLineAppService appService) { _appService = appService; }
    }
}