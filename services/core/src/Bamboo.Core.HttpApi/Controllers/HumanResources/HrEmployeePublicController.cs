using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrEmployeePublic")]
    public partial class HrEmployeePublicController : AbpController
    {
        private readonly IHrEmployeePublicAppService _appService;
        public HrEmployeePublicController(IHrEmployeePublicAppService appService) { _appService = appService; }
    }
}