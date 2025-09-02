using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosSession")]
    public partial class PosSessionController : AbpControllerBase
    {
        private readonly IPosSessionAppService _appService;
        public PosSessionController(IPosSessionAppService appService) { _appService = appService; }
    }
}