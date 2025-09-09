using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentTransaction")]
    public partial class PaymentTransactionController : AbpController
    {
        private readonly IPaymentTransactionAppService _appService;
        public PaymentTransactionController(IPaymentTransactionAppService appService) { _appService = appService; }
    }
}