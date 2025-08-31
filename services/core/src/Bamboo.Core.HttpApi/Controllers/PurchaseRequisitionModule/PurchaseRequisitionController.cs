using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PurchaseRequisitionModule
{
    [Route("api/v1/inventory/PurchaseRequisition")]
    public partial class PurchaseRequisitionController : AbpControllerBase
    {
        private readonly IPurchaseRequisitionAppService _appService;
        public PurchaseRequisitionController(IPurchaseRequisitionAppService appService) { _appService = appService; }
    }
}