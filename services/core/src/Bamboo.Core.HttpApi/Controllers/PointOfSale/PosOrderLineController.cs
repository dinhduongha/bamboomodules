using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosOrderLine")]
    public partial class PosOrderLineController : AbpControllerBase
    {
        private readonly IPosOrderLineAppService _appService;
        public PosOrderLineController(IPosOrderLineAppService appService) { _appService = appService; }
    }
}