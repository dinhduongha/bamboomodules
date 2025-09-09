using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosOrder")]
    public partial class PosOrderController : AbpController
    {
        private readonly IPosOrderAppService _appService;
        public PosOrderController(IPosOrderAppService appService) { _appService = appService; }
    }
}