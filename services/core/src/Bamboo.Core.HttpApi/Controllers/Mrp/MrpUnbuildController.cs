using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpUnbuild")]
    public partial class MrpUnbuildController : AbpControllerBase
    {
        private readonly IMrpUnbuildAppService _appService;
        public MrpUnbuildController(IMrpUnbuildAppService appService) { _appService = appService; }
    }
}