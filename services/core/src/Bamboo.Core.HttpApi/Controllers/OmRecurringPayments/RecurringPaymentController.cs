using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/RecurringPayment")]
    public partial class RecurringPaymentController : AbpControllerBase
    {
        private readonly IRecurringPaymentAppService _appService;
        public RecurringPaymentController(IRecurringPaymentAppService appService) { _appService = appService; }
    }
}