using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/RecurringPaymentLine")]
    public partial class RecurringPaymentLineController : AbpControllerBase
    {
        private readonly IRecurringPaymentLineAppService _appService;
        public RecurringPaymentLineController(IRecurringPaymentLineAppService appService) { _appService = appService; }
    }
}