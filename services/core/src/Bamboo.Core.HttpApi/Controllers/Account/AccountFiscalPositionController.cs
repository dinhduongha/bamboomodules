using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountFiscalPosition")]
    public partial class AccountFiscalPositionController : AbpControllerBase
    {
        private readonly IAccountFiscalPositionAppService _appService;
        public AccountFiscalPositionController(IAccountFiscalPositionAppService appService) { _appService = appService; }
    }
}