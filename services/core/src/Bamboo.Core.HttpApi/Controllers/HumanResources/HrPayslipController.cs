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
    [Route("api/v1/generic-modules/HrPayslip")]
    public partial class HrPayslipController : AbpController
    {
        private readonly IHrPayslipAppService _appService;
        public HrPayslipController(IHrPayslipAppService appService) { _appService = appService; }
    }
}