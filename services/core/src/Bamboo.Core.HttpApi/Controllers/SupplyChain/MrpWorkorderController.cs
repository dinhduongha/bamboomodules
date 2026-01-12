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
    // Category: Supply Chain/Manufacturing, Module: mrp
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/MrpWorkorder")]
    public partial class MrpWorkorderController : AbpController
    {
        private readonly IMrpWorkorderAppService _appService;
        public MrpWorkorderController(IMrpWorkorderAppService appService) { _appService = appService; }
    }
}