using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountLockException")]
    public partial class AccountLockExceptionController : AbpControllerBase
    {
        private readonly IAccountLockExceptionAppService _appService;
        public AccountLockExceptionController(IAccountLockExceptionAppService appService) { _appService = appService; }
    }
}