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
    [Route("api/v1/manufacturing/MaintenanceRequest")]
    public partial class MaintenanceRequestController : AbpController
    {
        private readonly IMaintenanceRequestAppService _appService;
        public MaintenanceRequestController(IMaintenanceRequestAppService appService) { _appService = appService; }
    }
}