using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpUnbuild")]
    public partial class MrpUnbuildController : AbpControllerBase
    {
        private readonly IMrpUnbuildAppService _appService;
        public MrpUnbuildController(IMrpUnbuildAppService appService) { _appService = appService; }
    }
}