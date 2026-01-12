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
    // Category: Inventory/Purchase, Module: purchase_requisition
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/inventory/PurchaseRequisition")]
    public partial class PurchaseRequisitionController : AbpController
    {
        private readonly IPurchaseRequisitionAppService _appService;
        public PurchaseRequisitionController(IPurchaseRequisitionAppService appService) { _appService = appService; }
    }
}