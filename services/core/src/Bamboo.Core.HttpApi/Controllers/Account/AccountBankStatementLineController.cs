using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountBankStatementLine")]
    public partial class AccountBankStatementLineController : AbpControllerBase
    {
        private readonly IAccountBankStatementLineAppService _appService;
        public AccountBankStatementLineController(IAccountBankStatementLineAppService appService) { _appService = appService; }
    }
}