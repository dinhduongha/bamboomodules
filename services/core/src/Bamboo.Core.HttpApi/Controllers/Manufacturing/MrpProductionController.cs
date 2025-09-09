using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpProduction")]
    public partial class MrpProductionController : AbpController
    {
        private readonly IMrpProductionAppService _appService;
        public MrpProductionController(IMrpProductionAppService appService) { _appService = appService; }
    }
}