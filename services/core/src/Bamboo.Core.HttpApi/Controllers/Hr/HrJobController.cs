using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    [Route("api/v1/human-resources/HrJob")]
    public partial class HrJobController : AbpControllerBase
    {
        private readonly IHrJobAppService _appService;
        public HrJobController(IHrJobAppService appService) { _appService = appService; }
    }
}