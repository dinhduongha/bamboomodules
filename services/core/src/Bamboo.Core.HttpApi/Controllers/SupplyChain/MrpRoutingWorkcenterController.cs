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
    [Route("api/v1/supply-chain/MrpRoutingWorkcenter")]
    public partial class MrpRoutingWorkcenterController : AbpController
    {
        private readonly IMrpRoutingWorkcenterAppService _appService;
        public MrpRoutingWorkcenterController(IMrpRoutingWorkcenterAppService appService) { _appService = appService; }
    }
}