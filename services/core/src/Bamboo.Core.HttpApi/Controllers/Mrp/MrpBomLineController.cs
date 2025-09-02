using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBomLine")]
    public partial class MrpBomLineController : AbpControllerBase
    {
        private readonly IMrpBomLineAppService _appService;
        public MrpBomLineController(IMrpBomLineAppService appService) { _appService = appService; }
    }
}