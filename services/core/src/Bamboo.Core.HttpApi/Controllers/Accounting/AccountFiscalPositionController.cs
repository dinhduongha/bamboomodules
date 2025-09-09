using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountFiscalPosition")]
    public partial class AccountFiscalPositionController : AbpController
    {
        private readonly IAccountFiscalPositionAppService _appService;
        public AccountFiscalPositionController(IAccountFiscalPositionAppService appService) { _appService = appService; }
    }
}