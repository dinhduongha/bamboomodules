using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountReport")]
    public partial class AccountReportController : AbpControllerBase
    {
        private readonly IAccountReportAppService _appService;
        public AccountReportController(IAccountReportAppService appService) { _appService = appService; }
    }
}