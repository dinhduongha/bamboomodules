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
    [Route("api/v1/human-resources/FleetVehicleLogContract")]
    public partial class FleetVehicleLogContractController : AbpController
    {
        private readonly IFleetVehicleLogContractAppService _appService;
        public FleetVehicleLogContractController(IFleetVehicleLogContractAppService appService) { _appService = appService; }
    }
}