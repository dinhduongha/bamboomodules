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
    [Route("api/v1/human-resources/FleetVehicleModel")]
    public partial class FleetVehicleModelController : AbpController
    {
        private readonly IFleetVehicleModelAppService _appService;
        public FleetVehicleModelController(IFleetVehicleModelAppService appService) { _appService = appService; }
    }
}