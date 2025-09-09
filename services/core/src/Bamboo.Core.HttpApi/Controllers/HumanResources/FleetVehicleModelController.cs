using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    [Route("api/v1/human-resources/FleetVehicleModel")]
    public partial class FleetVehicleModelController : AbpController
    {
        private readonly IFleetVehicleModelAppService _appService;
        public FleetVehicleModelController(IFleetVehicleModelAppService appService) { _appService = appService; }
    }
}