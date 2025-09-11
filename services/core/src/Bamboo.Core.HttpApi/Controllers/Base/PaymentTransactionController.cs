using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: payment
    [Authorize]
    [Route("api/v1/payment/PaymentTransaction")]
    public partial class PaymentTransactionController : AbpController
    {
        private readonly IPaymentTransactionAppService _appService;
        public PaymentTransactionController(IPaymentTransactionAppService appService) { _appService = appService; }
    }
}