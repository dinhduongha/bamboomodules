using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Payment
{
    [Route("api/v1/payment/PaymentToken")]
    public partial class PaymentTokenController : AbpControllerBase
    {
        private readonly IPaymentTokenAppService _appService;
        public PaymentTokenController(IPaymentTokenAppService appService) { _appService = appService; }
    }
}