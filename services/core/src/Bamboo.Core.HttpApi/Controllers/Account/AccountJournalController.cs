using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    [Route("api/v1/accounting/AccountJournal")]
    public partial class AccountJournalController : AbpControllerBase
    {
        private readonly IAccountJournalAppService _appService;
        public AccountJournalController(IAccountJournalAppService appService) { _appService = appService; }
    }
}