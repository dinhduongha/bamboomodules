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
    [Route("api/v1/accounting/AccountAnalyticAccount")]
    public partial class AccountAnalyticAccountController : AbpController
    {
        private readonly IAccountAnalyticAccountAppService _appService;
        public AccountAnalyticAccountController(IAccountAnalyticAccountAppService appService) { _appService = appService; }
    }
}