using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBomLine")]
    public partial class MrpBomLineController : AbpController
    {
        private readonly IMrpBomLineAppService _appService;
        public MrpBomLineController(IMrpBomLineAppService appService) { _appService = appService; }
    }
}