using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    [Route("api/v1/human-resources/FleetVehicleLogServices")]
    public partial class FleetVehicleLogServicesController : AbpControllerBase
    {
        private readonly IFleetVehicleLogServicesAppService _appService;
        public FleetVehicleLogServicesController(IFleetVehicleLogServicesAppService appService) { _appService = appService; }
    }
}