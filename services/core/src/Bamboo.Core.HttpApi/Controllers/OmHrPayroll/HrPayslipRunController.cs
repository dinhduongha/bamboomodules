using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayslipRun")]
    public partial class HrPayslipRunController : AbpControllerBase
    {
        private readonly IHrPayslipRunAppService _appService;
        public HrPayslipRunController(IHrPayslipRunAppService appService) { _appService = appService; }
    }
}