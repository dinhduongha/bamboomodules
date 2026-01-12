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
    [Route("api/v1/payment/PaymentToken")]
    public partial class PaymentTokenController : AbpController
    {
        private readonly IPaymentTokenAppService _appService;
        public PaymentTokenController(IPaymentTokenAppService appService) { _appService = appService; }
    }
}