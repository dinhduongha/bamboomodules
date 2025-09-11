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
    // Category: Manufacturing/Maintenance, Module: maintenance
    [Authorize]
    [Route("api/v1/manufacturing/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpController
    {
        private readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
    }
}