using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticDistributionModel")]
    public partial class AccountAnalyticDistributionModelController : AbpController
    {
        private readonly IAccountAnalyticDistributionModelAppService _appService;
        public AccountAnalyticDistributionModelController(IAccountAnalyticDistributionModelAppService appService) { _appService = appService; }
    }
}