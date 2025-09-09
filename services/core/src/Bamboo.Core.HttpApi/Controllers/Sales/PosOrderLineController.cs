using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosOrderLine")]
    public partial class PosOrderLineController : AbpController
    {
        private readonly IPosOrderLineAppService _appService;
        public PosOrderLineController(IPosOrderLineAppService appService) { _appService = appService; }
    }
}