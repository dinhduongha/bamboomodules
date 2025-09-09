using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseOrder")]
    public partial class PurchaseOrderController : AbpController
    {
        private readonly IPurchaseOrderAppService _appService;
        public PurchaseOrderController(IPurchaseOrderAppService appService) { _appService = appService; }
    }
}