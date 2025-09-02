using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    [Route("api/v1/manufacturing/MrpBomByproduct")]
    public partial class MrpBomByproductController : AbpControllerBase
    {
        private readonly IMrpBomByproductAppService _appService;
        public MrpBomByproductController(IMrpBomByproductAppService appService) { _appService = appService; }
    }
}