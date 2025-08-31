using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    [Route("api/v1/manufacturing/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpControllerBase
    {
        private readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
    }
}