using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    [Route("api/v1/human-resources/FleetVehicleModel")]
    public partial class FleetVehicleModelController : AbpControllerBase
    {
        private readonly IFleetVehicleModelAppService _appService;
        public FleetVehicleModelController(IFleetVehicleModelAppService appService) { _appService = appService; }
    }
}