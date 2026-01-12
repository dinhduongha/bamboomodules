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
    // Category: Sales/Sales, Module: sale
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/SaleOrder")]
    public partial class SaleOrderController : AbpController
    {
        private readonly ISaleOrderAppService _appService;
        public SaleOrderController(ISaleOrderAppService appService) { _appService = appService; }
    }
}