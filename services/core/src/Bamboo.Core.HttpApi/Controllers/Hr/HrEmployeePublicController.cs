using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployeePublic")]
    public partial class HrEmployeePublicController : AbpControllerBase
    {
        private readonly IHrEmployeePublicAppService _appService;
        public HrEmployeePublicController(IHrEmployeePublicAppService appService) { _appService = appService; }
    }
}