using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayslipRun")]
    public partial class HrPayslipRunController : AbpControllerBase
    {
        private readonly IHrPayslipRunAppService _appService;
        public HrPayslipRunController(IHrPayslipRunAppService appService) { _appService = appService; }
    }
}