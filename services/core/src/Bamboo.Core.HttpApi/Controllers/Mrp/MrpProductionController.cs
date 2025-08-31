using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpProduction")]
    public partial class MrpProductionController : AbpControllerBase
    {
        private readonly IMrpProductionAppService _appService;
        public MrpProductionController(IMrpProductionAppService appService) { _appService = appService; }
    }
}