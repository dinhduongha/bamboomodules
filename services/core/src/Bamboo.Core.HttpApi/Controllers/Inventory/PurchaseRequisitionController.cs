using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PurchaseRequisitionModule
{
    [Route("api/v1/inventory/PurchaseRequisition")]
    public partial class PurchaseRequisitionController : AbpController
    {
        private readonly IPurchaseRequisitionAppService _appService;
        public PurchaseRequisitionController(IPurchaseRequisitionAppService appService) { _appService = appService; }
    }
}