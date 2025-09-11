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
    // Category: Human Resources/Fleet, Module: fleet
    [Authorize]
    [Route("api/v1/human-resources/FleetVehicleLogServices")]
    public partial class FleetVehicleLogServicesController : AbpController
    {
        private readonly IFleetVehicleLogServicesAppService _appService;
        public FleetVehicleLogServicesController(IFleetVehicleLogServicesAppService appService) { _appService = appService; }
    }
}