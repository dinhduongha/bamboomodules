using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Fleet, Module: fleet
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/FleetVehicle")]
    public partial class FleetVehicleController : AbpController
    {
        private readonly IFleetVehicleAppService _appService;
        public FleetVehicleController(IFleetVehicleAppService appService) { _appService = appService; }
    }
}