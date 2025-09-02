using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountFiscalPosition")]
    public partial class AccountFiscalPositionController : AbpControllerBase
    {
        private readonly IAccountFiscalPositionAppService _appService;
        public AccountFiscalPositionController(IAccountFiscalPositionAppService appService) { _appService = appService; }
    }
}