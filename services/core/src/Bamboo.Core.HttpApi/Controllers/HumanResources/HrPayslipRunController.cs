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
    [Route("api/v1/generic-modules/HrPayslipRun")]
    public partial class HrPayslipRunController : AbpController
    {
        private readonly IHrPayslipRunAppService _appService;
        public HrPayslipRunController(IHrPayslipRunAppService appService) { _appService = appService; }
    }
}