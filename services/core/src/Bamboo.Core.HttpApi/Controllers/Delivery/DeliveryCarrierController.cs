using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Delivery
{
    [Route("api/v1/sales/DeliveryCarrier")]
    public partial class DeliveryCarrierController : AbpControllerBase
    {
        private readonly IDeliveryCarrierAppService _appService;
        public DeliveryCarrierController(IDeliveryCarrierAppService appService) { _appService = appService; }
    }
}