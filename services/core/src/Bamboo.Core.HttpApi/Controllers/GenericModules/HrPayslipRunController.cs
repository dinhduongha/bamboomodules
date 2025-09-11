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
    // Category: Generic Modules/Human Resources, Module: om_hr_payroll
    [Authorize]
    [Route("api/v1/generic-modules/HrPayslipRun")]
    public partial class HrPayslipRunController : AbpController
    {
        private readonly IHrPayslipRunAppService _appService;
        public HrPayslipRunController(IHrPayslipRunAppService appService) { _appService = appService; }
    }
}