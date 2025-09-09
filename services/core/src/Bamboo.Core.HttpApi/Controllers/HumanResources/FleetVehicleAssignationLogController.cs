using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    [Route("api/v1/human-resources/FleetVehicleAssignationLog")]
    public partial class FleetVehicleAssignationLogController : AbpController
    {
        private readonly IFleetVehicleAssignationLogAppService _appService;
        public FleetVehicleAssignationLogController(IFleetVehicleAssignationLogAppService appService) { _appService = appService; }
    }
}