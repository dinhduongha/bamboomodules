using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosOrder")]
    public partial class PosOrderController : AbpControllerBase
    {
        private readonly IPosOrderAppService _appService;
        public PosOrderController(IPosOrderAppService appService) { _appService = appService; }
    }
}