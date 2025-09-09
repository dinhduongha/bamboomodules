using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentToken")]
    public partial class PaymentTokenController : AbpController
    {
        private readonly IPaymentTokenAppService _appService;
        public PaymentTokenController(IPaymentTokenAppService appService) { _appService = appService; }
    }
}