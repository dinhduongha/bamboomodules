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
    // Category: Inventory/Purchase, Module: purchase
    [Authorize]
    [Route("api/v1/inventory/PurchaseOrderLine")]
    public partial class PurchaseOrderLineController : AbpController
    {
        private readonly IPurchaseOrderLineAppService _appService;
        public PurchaseOrderLineController(IPurchaseOrderLineAppService appService) { _appService = appService; }
    }
}