using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountMoveLine")]
    public partial class AccountMoveLineController : AbpController
    {
        private readonly IAccountMoveLineAppService _appService;
        public AccountMoveLineController(IAccountMoveLineAppService appService) { _appService = appService; }
    }
}