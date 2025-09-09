using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpWorkorder")]
    public partial class MrpWorkorderController : AbpController
    {
        private readonly IMrpWorkorderAppService _appService;
        public MrpWorkorderController(IMrpWorkorderAppService appService) { _appService = appService; }
    }
}