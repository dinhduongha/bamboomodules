using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBom")]
    public partial class MrpBomController : AbpControllerBase
    {
        private readonly IMrpBomAppService _appService;
        public MrpBomController(IMrpBomAppService appService) { _appService = appService; }
    }
}