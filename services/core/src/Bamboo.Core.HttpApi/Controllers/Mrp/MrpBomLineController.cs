using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBomLine")]
    public partial class MrpBomLineController : AbpControllerBase
    {
        private readonly IMrpBomLineAppService _appService;
        public MrpBomLineController(IMrpBomLineAppService appService) { _appService = appService; }
    }
}