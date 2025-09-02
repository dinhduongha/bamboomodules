using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    [Route("api/v1/manufacturing/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpControllerBase
    {
        private readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
    }
}