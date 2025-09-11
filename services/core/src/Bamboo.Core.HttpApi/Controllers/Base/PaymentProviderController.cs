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
    [Route("api/v1/payment/PaymentProvider")]
    public partial class PaymentProviderController : AbpController
    {
        private readonly IPaymentProviderAppService _appService;
        public PaymentProviderController(IPaymentProviderAppService appService) { _appService = appService; }
    }
}