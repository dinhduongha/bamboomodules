using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpWorkcenterProductivity")]
    public partial class MrpWorkcenterProductivityController : AbpControllerBase
    {
        private readonly IMrpWorkcenterProductivityAppService _appService;
        public MrpWorkcenterProductivityController(IMrpWorkcenterProductivityAppService appService) { _appService = appService; }
    }
}