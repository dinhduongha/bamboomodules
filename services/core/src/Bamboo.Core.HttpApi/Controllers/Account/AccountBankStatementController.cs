using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountBankStatement")]
    public partial class AccountBankStatementController : AbpControllerBase
    {
        private readonly IAccountBankStatementAppService _appService;
        public AccountBankStatementController(IAccountBankStatementAppService appService) { _appService = appService; }
    }
}