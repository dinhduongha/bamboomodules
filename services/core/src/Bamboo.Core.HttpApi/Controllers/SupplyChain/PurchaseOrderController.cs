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
    [Route("api/v1/inventory/PurchaseOrder")]
    public partial class PurchaseOrderController : AbpController
    {
        private readonly IPurchaseOrderAppService _appService;
        public PurchaseOrderController(IPurchaseOrderAppService appService) { _appService = appService; }
    }
}