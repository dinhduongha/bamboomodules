using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentProvider")]
    public partial class PaymentProviderController : AbpControllerBase
    {
        private readonly IPaymentProviderAppService _appService;
        public PaymentProviderController(IPaymentProviderAppService appService) { _appService = appService; }
    }
}