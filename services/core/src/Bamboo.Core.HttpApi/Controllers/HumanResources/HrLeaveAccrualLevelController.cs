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
    // Category: Human Resources/Time Off, Module: hr_holidays
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrLeaveAccrualLevel")]
    public partial class HrLeaveAccrualLevelController : AbpController
    {
        private readonly IHrLeaveAccrualLevelAppService _appService;
        public HrLeaveAccrualLevelController(IHrLeaveAccrualLevelAppService appService) { _appService = appService; }
    }
}