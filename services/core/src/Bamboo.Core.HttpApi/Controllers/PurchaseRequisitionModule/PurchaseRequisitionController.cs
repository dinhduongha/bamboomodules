using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PurchaseRequisitionModule
{
    [Route("api/v1/inventory/PurchaseRequisition")]
    public partial class PurchaseRequisitionController : AbpControllerBase
    {
        private readonly IPurchaseRequisitionAppService _appService;
        public PurchaseRequisitionController(IPurchaseRequisitionAppService appService) { _appService = appService; }
    }
}