using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticAccount")]
    public partial class AccountAnalyticAccountController : AbpControllerBase
    {
        private readonly IAccountAnalyticAccountAppService _appService;
        public AccountAnalyticAccountController(IAccountAnalyticAccountAppService appService) { _appService = appService; }
    }
}