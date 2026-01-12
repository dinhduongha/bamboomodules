using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Point of Sale, Module: point_of_sale
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/PosOrder")]
    public partial class PosOrderController : AbpController
    {
        private readonly IPosOrderAppService _appService;
        public PosOrderController(IPosOrderAppService appService) { _appService = appService; }
    }
}