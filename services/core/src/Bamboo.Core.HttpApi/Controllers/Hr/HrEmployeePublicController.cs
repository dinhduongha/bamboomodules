using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployeePublic")]
    public partial class HrEmployeePublicController : AbpControllerBase
    {
        private readonly IHrEmployeePublicAppService _appService;
        public HrEmployeePublicController(IHrEmployeePublicAppService appService) { _appService = appService; }
    }
}