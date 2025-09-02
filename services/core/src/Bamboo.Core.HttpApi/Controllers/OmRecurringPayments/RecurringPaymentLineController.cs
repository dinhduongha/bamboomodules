using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/RecurringPaymentLine")]
    public partial class RecurringPaymentLineController : AbpControllerBase
    {
        private readonly IRecurringPaymentLineAppService _appService;
        public RecurringPaymentLineController(IRecurringPaymentLineAppService appService) { _appService = appService; }
    }
}