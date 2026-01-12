using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Manufacturing/Manufacturing, Module: mrp
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/manufacturing/MrpBomLine")]
    public partial class MrpBomLineController : AbpController
    {
        private readonly IMrpBomLineAppService _appService;
        public MrpBomLineController(IMrpBomLineAppService appService) { _appService = appService; }
    }
}