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
    // Category: Sales/Delivery, Module: delivery
    [Authorize]
    [Route("api/v1/sales/DeliveryCarrier")]
    public partial class DeliveryCarrierController : AbpController
    {
        private readonly IDeliveryCarrierAppService _appService;
        public DeliveryCarrierController(IDeliveryCarrierAppService appService) { _appService = appService; }
    }
}