using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticDistributionModel")]
    public partial class AccountAnalyticDistributionModelController : AbpControllerBase
    {
        private readonly IAccountAnalyticDistributionModelAppService _appService;
        public AccountAnalyticDistributionModelController(IAccountAnalyticDistributionModelAppService appService) { _appService = appService; }
    }
}