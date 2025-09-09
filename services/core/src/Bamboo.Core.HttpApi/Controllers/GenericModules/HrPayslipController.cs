using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayslip")]
    public partial class HrPayslipController : AbpController
    {
        private readonly IHrPayslipAppService _appService;
        public HrPayslipController(IHrPayslipAppService appService) { _appService = appService; }
    }
}