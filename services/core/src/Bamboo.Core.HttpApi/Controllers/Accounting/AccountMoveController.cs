using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting/Accounting, Module: account
    [Authorize]
    [Route("api/v1/accounting/AccountMove")]
    public partial class AccountMoveController : AbpController
    {
        private readonly IAccountMoveAppService _appService;
        public AccountMoveController(IAccountMoveAppService appService) { _appService = appService; }
    }
}