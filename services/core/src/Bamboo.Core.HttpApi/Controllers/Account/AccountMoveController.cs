using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountMove")]
    public partial class AccountMoveController : AbpControllerBase
    {
        private readonly IAccountMoveAppService _appService;
        public AccountMoveController(IAccountMoveAppService appService) { _appService = appService; }
    }
}