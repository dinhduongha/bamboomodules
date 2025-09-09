using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpWorkcenter")]
    public partial class MrpWorkcenterController : AbpController
    {
        private readonly IMrpWorkcenterAppService _appService;
        public MrpWorkcenterController(IMrpWorkcenterAppService appService) { _appService = appService; }
    }
}