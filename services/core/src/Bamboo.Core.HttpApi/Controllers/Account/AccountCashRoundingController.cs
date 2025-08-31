using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountCashRounding")]
    public partial class AccountCashRoundingController : AbpControllerBase
    {
        private readonly IAccountCashRoundingAppService _appService;
        public AccountCashRoundingController(IAccountCashRoundingAppService appService) { _appService = appService; }
    }
}