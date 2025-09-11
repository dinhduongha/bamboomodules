using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Manufacturing/Manufacturing, Module: mrp
    [Authorize]
    [Route("api/v1/manufacturing/MrpBomByproduct")]
    public partial class MrpBomByproductController : AbpController
    {
        private readonly IMrpBomByproductAppService _appService;
        public MrpBomByproductController(IMrpBomByproductAppService appService) { _appService = appService; }
    }
}