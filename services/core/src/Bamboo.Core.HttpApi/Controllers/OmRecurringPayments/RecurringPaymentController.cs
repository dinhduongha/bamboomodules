using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    [Route("api/v1/accounting/RecurringPayment")]
    public partial class RecurringPaymentController : AbpControllerBase
    {
        private readonly IRecurringPaymentAppService _appService;
        public RecurringPaymentController(IRecurringPaymentAppService appService) { _appService = appService; }
    }
}