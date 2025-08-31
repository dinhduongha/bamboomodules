using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayrollStructure")]
    public partial class HrPayrollStructureController : AbpControllerBase
    {
        private readonly IHrPayrollStructureAppService _appService;
        public HrPayrollStructureController(IHrPayrollStructureAppService appService) { _appService = appService; }
    }
}