using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountAccount")]
    public partial class AccountAccountController : AbpControllerBase
    {
        private readonly IAccountAccountAppService _appService;
        public AccountAccountController(IAccountAccountAppService appService) { _appService = appService; }
    }
}