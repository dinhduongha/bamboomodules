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
    [Route("api/v1/accounting/AccountAccount")]
    public partial class AccountAccountController : AbpController
    {
        private readonly IAccountAccountAppService _appService;
        public AccountAccountController(IAccountAccountAppService appService) { _appService = appService; }
    }
}