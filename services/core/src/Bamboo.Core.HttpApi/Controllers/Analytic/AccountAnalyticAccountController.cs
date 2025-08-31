using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    [Route("api/v1/accounting/AccountAnalyticAccount")]
    public partial class AccountAnalyticAccountController : AbpControllerBase
    {
        private readonly IAccountAnalyticAccountAppService _appService;
        public AccountAnalyticAccountController(IAccountAnalyticAccountAppService appService) { _appService = appService; }
    }
}