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
    [Route("api/v1/manufacturing/MrpRoutingWorkcenter")]
    public partial class MrpRoutingWorkcenterController : AbpController
    {
        private readonly IMrpRoutingWorkcenterAppService _appService;
        public MrpRoutingWorkcenterController(IMrpRoutingWorkcenterAppService appService) { _appService = appService; }
    }
}