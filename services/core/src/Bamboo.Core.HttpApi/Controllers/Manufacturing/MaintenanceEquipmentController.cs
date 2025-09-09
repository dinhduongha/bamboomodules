using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    [Route("api/v1/manufacturing/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpController
    {
        private readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
    }
}