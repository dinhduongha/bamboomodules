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
    // Category: Manufacturing/Maintenance, Module: maintenance
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/manufacturing/MaintenanceRequest")]
    public partial class MaintenanceRequestController : AbpController
    {
        private readonly IMaintenanceRequestAppService _appService;
        public MaintenanceRequestController(IMaintenanceRequestAppService appService) { _appService = appService; }
    }
}