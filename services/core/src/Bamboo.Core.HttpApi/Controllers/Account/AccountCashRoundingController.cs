using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountCashRounding")]
    public partial class AccountCashRoundingController : AbpControllerBase
    {
        private readonly IAccountCashRoundingAppService _appService;
        public AccountCashRoundingController(IAccountCashRoundingAppService appService) { _appService = appService; }
    }
}