using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Repair
{
    [Route("api/v1/inventory/RepairOrder")]
    public partial class RepairOrderController : AbpControllerBase
    {
        private readonly IRepairOrderAppService _appService;
        public RepairOrderController(IRepairOrderAppService appService) { _appService = appService; }
    }
}