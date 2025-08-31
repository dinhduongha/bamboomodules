using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountReconcileModel")]
    public partial class AccountReconcileModelController : AbpControllerBase
    {
        private readonly IAccountReconcileModelAppService _appService;
        public AccountReconcileModelController(IAccountReconcileModelAppService appService) { _appService = appService; }
    }
}