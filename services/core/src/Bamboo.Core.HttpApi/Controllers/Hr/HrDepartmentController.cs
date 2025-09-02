using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrDepartment")]
    public partial class HrDepartmentController : AbpControllerBase
    {
        private readonly IHrDepartmentAppService _appService;
        public HrDepartmentController(IHrDepartmentAppService appService) { _appService = appService; }
    }
}