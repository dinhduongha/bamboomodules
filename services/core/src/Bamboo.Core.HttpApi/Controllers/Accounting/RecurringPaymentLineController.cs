using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/RecurringPaymentLine")]
    public partial class RecurringPaymentLineController : AbpController
    {
        private readonly IRecurringPaymentLineAppService _appService;
        public RecurringPaymentLineController(IRecurringPaymentLineAppService appService) { _appService = appService; }
    }
}