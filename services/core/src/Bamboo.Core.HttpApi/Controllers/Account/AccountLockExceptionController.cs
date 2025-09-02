using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountLockException")]
    public partial class AccountLockExceptionController : AbpControllerBase
    {
        private readonly IAccountLockExceptionAppService _appService;
        public AccountLockExceptionController(IAccountLockExceptionAppService appService) { _appService = appService; }
    }
}