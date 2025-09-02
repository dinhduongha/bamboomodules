using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticDistributionModel")]
    public partial class AccountAnalyticDistributionModelController : AbpControllerBase
    {
        private readonly IAccountAnalyticDistributionModelAppService _appService;
        public AccountAnalyticDistributionModelController(IAccountAnalyticDistributionModelAppService appService) { _appService = appService; }
    }
}