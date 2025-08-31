using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    [Route("api/v1/human-resources/FleetVehicleModel")]
    public partial class FleetVehicleModelController : AbpControllerBase
    {
        private readonly IFleetVehicleModelAppService _appService;
        public FleetVehicleModelController(IFleetVehicleModelAppService appService) { _appService = appService; }
    }
}