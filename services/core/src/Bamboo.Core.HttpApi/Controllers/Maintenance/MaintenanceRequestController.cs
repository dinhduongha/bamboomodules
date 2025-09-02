using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    [Route("api/v1/manufacturing/MaintenanceRequest")]
    public partial class MaintenanceRequestController : AbpControllerBase
    {
        private readonly IMaintenanceRequestAppService _appService;
        public MaintenanceRequestController(IMaintenanceRequestAppService appService) { _appService = appService; }
    }
}