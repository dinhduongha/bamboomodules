using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticLine")]
    public partial class AccountAnalyticLineController : AbpControllerBase
    {
        private readonly IAccountAnalyticLineAppService _appService;
        public AccountAnalyticLineController(IAccountAnalyticLineAppService appService) { _appService = appService; }
    }
}