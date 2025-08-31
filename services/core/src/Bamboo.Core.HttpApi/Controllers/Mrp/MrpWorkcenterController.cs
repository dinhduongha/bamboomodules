using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpWorkcenter")]
    public partial class MrpWorkcenterController : AbpControllerBase
    {
        private readonly IMrpWorkcenterAppService _appService;
        public MrpWorkcenterController(IMrpWorkcenterAppService appService) { _appService = appService; }
    }
}