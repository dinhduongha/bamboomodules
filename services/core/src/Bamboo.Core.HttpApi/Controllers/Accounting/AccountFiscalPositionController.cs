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
    [Route("api/v1/accounting/AccountFiscalPosition")]
    public partial class AccountFiscalPositionController : AbpController
    {
        private readonly IAccountFiscalPositionAppService _appService;
        public AccountFiscalPositionController(IAccountFiscalPositionAppService appService) { _appService = appService; }
    }
}