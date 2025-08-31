using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/AccountRecurringTemplate")]
    public partial class AccountRecurringTemplateController : AbpControllerBase
    {
        private readonly IAccountRecurringTemplateAppService _appService;
        public AccountRecurringTemplateController(IAccountRecurringTemplateAppService appService) { _appService = appService; }
    }
}