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
    // Category: Inventory/Inventory, Module: repair
    [Authorize]
    [Route("api/v1/inventory/RepairOrder")]
    public partial class RepairOrderController : AbpController
    {
        private readonly IRepairOrderAppService _appService;
        public RepairOrderController(IRepairOrderAppService appService) { _appService = appService; }
    }
}