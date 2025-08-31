using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayslip")]
    public partial class HrPayslipController : AbpControllerBase
    {
        private readonly IHrPayslipAppService _appService;
        public HrPayslipController(IHrPayslipAppService appService) { _appService = appService; }
    }
}