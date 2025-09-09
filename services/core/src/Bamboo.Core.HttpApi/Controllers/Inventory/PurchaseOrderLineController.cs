using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseOrderLine")]
    public partial class PurchaseOrderLineController : AbpController
    {
        private readonly IPurchaseOrderLineAppService _appService;
        public PurchaseOrderLineController(IPurchaseOrderLineAppService appService) { _appService = appService; }
    }
}