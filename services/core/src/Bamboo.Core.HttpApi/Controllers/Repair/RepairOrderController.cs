using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Repair
{
    [Route("api/v1/inventory/RepairOrder")]
    public partial class RepairOrderController : AbpControllerBase
    {
        private readonly IRepairOrderAppService _appService;
        public RepairOrderController(IRepairOrderAppService appService) { _appService = appService; }
    }
}