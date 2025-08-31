using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountJournal")]
    public partial class AccountJournalController : AbpControllerBase
    {
        private readonly IAccountJournalAppService _appService;
        public AccountJournalController(IAccountJournalAppService appService) { _appService = appService; }
    }
}