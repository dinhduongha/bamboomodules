using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Supply Chain/Manufacturing, Module: mrp
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/MrpWorkcenterProductivity")]
    public partial class MrpWorkcenterProductivityController : AbpController
    {
        private readonly IMrpWorkcenterProductivityAppService _appService;
        public MrpWorkcenterProductivityController(IMrpWorkcenterProductivityAppService appService) { _appService = appService; }
    }
}