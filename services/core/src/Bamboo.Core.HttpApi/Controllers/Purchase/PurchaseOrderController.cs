using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseOrder")]
    public partial class PurchaseOrderController : AbpControllerBase
    {
        private readonly IPurchaseOrderAppService _appService;
        public PurchaseOrderController(IPurchaseOrderAppService appService) { _appService = appService; }
    }
}