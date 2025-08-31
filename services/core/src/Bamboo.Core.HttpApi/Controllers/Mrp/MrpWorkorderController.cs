using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpWorkorder")]
    public partial class MrpWorkorderController : AbpControllerBase
    {
        private readonly IMrpWorkorderAppService _appService;
        public MrpWorkorderController(IMrpWorkorderAppService appService) { _appService = appService; }
    }
}