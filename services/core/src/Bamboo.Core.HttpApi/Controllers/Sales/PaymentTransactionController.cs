using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: payment
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/payment/PaymentTransaction")]
    public partial class PaymentTransactionController : AbpController
    {
        private readonly IPaymentTransactionAppService _appService;
        public PaymentTransactionController(IPaymentTransactionAppService appService) { _appService = appService; }
    }
}