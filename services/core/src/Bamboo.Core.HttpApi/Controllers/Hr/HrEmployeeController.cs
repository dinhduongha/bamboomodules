using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployee")]
    public partial class HrEmployeeController : AbpControllerBase
    {
        private readonly IHrEmployeeAppService _appService;
        public HrEmployeeController(IHrEmployeeAppService appService) { _appService = appService; }
    }
}