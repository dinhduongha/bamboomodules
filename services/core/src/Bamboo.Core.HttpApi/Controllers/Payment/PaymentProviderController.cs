using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentProvider")]
    public partial class PaymentProviderController : AbpControllerBase
    {
        private readonly IPaymentProviderAppService _appService;
        public PaymentProviderController(IPaymentProviderAppService appService) { _appService = appService; }
    }
}