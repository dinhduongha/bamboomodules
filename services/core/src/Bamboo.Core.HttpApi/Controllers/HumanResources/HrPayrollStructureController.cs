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
    // Category: Generic Modules/Human Resources, Module: om_hr_payroll
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/generic-modules/HrPayrollStructure")]
    public partial class HrPayrollStructureController : AbpController
    {
        private readonly IHrPayrollStructureAppService _appService;
        public HrPayrollStructureController(IHrPayrollStructureAppService appService) { _appService = appService; }
    }
}