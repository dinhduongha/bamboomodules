using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseOrderLine")]
    public partial class PurchaseOrderLineController : AbpControllerBase
    {
        private readonly IPurchaseOrderLineAppService _appService;
        public PurchaseOrderLineController(IPurchaseOrderLineAppService appService) { _appService = appService; }
    }
}