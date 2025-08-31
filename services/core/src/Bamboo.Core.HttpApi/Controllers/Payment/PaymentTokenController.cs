using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentToken")]
    public partial class PaymentTokenController : AbpControllerBase
    {
        private readonly IPaymentTokenAppService _appService;
        public PaymentTokenController(IPaymentTokenAppService appService) { _appService = appService; }
    }
}