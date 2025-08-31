using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticLine")]
    public partial class AccountAnalyticLineController : AbpControllerBase
    {
        private readonly IAccountAnalyticLineAppService _appService;
        public AccountAnalyticLineController(IAccountAnalyticLineAppService appService) { _appService = appService; }
    }
}