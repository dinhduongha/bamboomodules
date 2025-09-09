using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountReconcileModel")]
    public partial class AccountReconcileModelController : AbpController
    {
        private readonly IAccountReconcileModelAppService _appService;
        public AccountReconcileModelController(IAccountReconcileModelAppService appService) { _appService = appService; }
    }
}