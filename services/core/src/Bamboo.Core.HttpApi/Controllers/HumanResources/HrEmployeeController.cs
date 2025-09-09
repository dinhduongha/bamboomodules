using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployee")]
    public partial class HrEmployeeController : AbpController
    {
        private readonly IHrEmployeeAppService _appService;
        public HrEmployeeController(IHrEmployeeAppService appService) { _appService = appService; }
    }
}