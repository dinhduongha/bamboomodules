using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpRoutingWorkcenter")]
    public partial class MrpRoutingWorkcenterController : AbpControllerBase
    {
        private readonly IMrpRoutingWorkcenterAppService _appService;
        public MrpRoutingWorkcenterController(IMrpRoutingWorkcenterAppService appService) { _appService = appService; }
    }
}