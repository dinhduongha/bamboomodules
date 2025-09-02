using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployee")]
    public partial class HrEmployeeController : AbpControllerBase
    {
        private readonly IHrEmployeeAppService _appService;
        public HrEmployeeController(IHrEmployeeAppService appService) { _appService = appService; }
    }
}