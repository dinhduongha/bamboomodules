using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Manufacturing/Manufacturing, Module: mrp
    [Authorize]
    [Route("api/v1/manufacturing/MrpWorkcenterProductivity")]
    public partial class MrpWorkcenterProductivityController : AbpController
    {
        private readonly IMrpWorkcenterProductivityAppService _appService;
        public MrpWorkcenterProductivityController(IMrpWorkcenterProductivityAppService appService) { _appService = appService; }
    }
}