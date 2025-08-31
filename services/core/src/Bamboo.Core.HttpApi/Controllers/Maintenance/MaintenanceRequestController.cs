using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    [Route("api/v1/manufacturing/MaintenanceRequest")]
    public partial class MaintenanceRequestController : AbpControllerBase
    {
        private readonly IMaintenanceRequestAppService _appService;
        public MaintenanceRequestController(IMaintenanceRequestAppService appService) { _appService = appService; }
    }
}