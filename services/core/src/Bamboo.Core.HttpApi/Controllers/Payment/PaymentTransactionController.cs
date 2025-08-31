using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentTransaction")]
    public partial class PaymentTransactionController : AbpControllerBase
    {
        private readonly IPaymentTransactionAppService _appService;
        public PaymentTransactionController(IPaymentTransactionAppService appService) { _appService = appService; }
    }
}