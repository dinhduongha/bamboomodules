using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrDepartment")]
    public partial class HrDepartmentController : AbpControllerBase
    {
        private readonly IHrDepartmentAppService _appService;
        public HrDepartmentController(IHrDepartmentAppService appService) { _appService = appService; }
    }
}