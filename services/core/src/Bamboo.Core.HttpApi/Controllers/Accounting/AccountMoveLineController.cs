using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting/Accounting, Module: account
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountMoveLine")]
    public partial class AccountMoveLineController : AbpController
    {
        private readonly IAccountMoveLineAppService _appService;
        public AccountMoveLineController(IAccountMoveLineAppService appService) { _appService = appService; }
    }
}