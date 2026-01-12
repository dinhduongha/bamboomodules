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
    // Category: Supply Chain/Maintenance, Module: maintenance
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpController
    {
        private readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
    }
}