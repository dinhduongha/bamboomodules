using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpUnbuild")]
    public partial class MrpUnbuildController : AbpController
    {
        private readonly IMrpUnbuildAppService _appService;
        public MrpUnbuildController(IMrpUnbuildAppService appService) { _appService = appService; }
    }
}