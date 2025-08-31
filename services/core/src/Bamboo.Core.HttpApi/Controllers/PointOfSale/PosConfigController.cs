using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosConfig")]
    public partial class PosConfigController : AbpControllerBase
    {
        private readonly IPosConfigAppService _appService;
        public PosConfigController(IPosConfigAppService appService) { _appService = appService; }
    }
}