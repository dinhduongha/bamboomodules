using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Delivery
{
    [Route("api/v1/sales/DeliveryCarrier")]
    public partial class DeliveryCarrierController : AbpControllerBase
    {
        private readonly IDeliveryCarrierAppService _appService;
        public DeliveryCarrierController(IDeliveryCarrierAppService appService) { _appService = appService; }
    }
}