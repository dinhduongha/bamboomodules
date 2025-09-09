using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmHrPayroll
{
    [Route("api/v1/generic-modules/HrPayrollStructure")]
    public partial class HrPayrollStructureController : AbpController
    {
        private readonly IHrPayrollStructureAppService _appService;
        public HrPayrollStructureController(IHrPayrollStructureAppService appService) { _appService = appService; }
    }
}