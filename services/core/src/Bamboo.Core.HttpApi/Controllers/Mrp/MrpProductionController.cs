using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpProduction")]
    public partial class MrpProductionController : AbpControllerBase
    {
        private readonly IMrpProductionAppService _appService;
        public MrpProductionController(IMrpProductionAppService appService) { _appService = appService; }
    }
}