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
    // Category: Human Resources/Employees, Module: hr
    [Authorize]
    [Route("api/v1/human-resources/HrEmployee")]
    public partial class HrEmployeeController : AbpController
    {
        private readonly IHrEmployeeAppService _appService;
        public HrEmployeeController(IHrEmployeeAppService appService) { _appService = appService; }
    }
}