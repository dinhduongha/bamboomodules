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
    // Category: Sales/Delivery, Module: delivery
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/DeliveryCarrier")]
    public partial class DeliveryCarrierController : AbpController
    {
        private readonly IDeliveryCarrierAppService _appService;
        public DeliveryCarrierController(IDeliveryCarrierAppService appService) { _appService = appService; }
    }
}