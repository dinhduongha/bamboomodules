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
    // Category: Inventory/Purchase, Module: purchase
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/inventory/PurchaseOrderLine")]
    public partial class PurchaseOrderLineController : AbpController
    {
        private readonly IPurchaseOrderLineAppService _appService;
        public PurchaseOrderLineController(IPurchaseOrderLineAppService appService) { _appService = appService; }
    }
}