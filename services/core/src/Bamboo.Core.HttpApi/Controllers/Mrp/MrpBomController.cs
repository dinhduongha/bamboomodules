using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBom")]
    public partial class MrpBomController : AbpControllerBase
    {
        private readonly IMrpBomAppService _appService;
        public MrpBomController(IMrpBomAppService appService) { _appService = appService; }
    }
}