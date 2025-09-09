using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/AccountRecurringTemplate")]
    public partial class AccountRecurringTemplateController : AbpController
    {
        private readonly IAccountRecurringTemplateAppService _appService;
        public AccountRecurringTemplateController(IAccountRecurringTemplateAppService appService) { _appService = appService; }
    }
}