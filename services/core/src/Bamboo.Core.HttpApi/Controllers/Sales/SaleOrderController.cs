using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: sale
    [Authorize]
    [Route("api/v1/sales/SaleOrder")]
    public partial class SaleOrderController : AbpController
    {
        private readonly ISaleOrderAppService _appService;
        public SaleOrderController(ISaleOrderAppService appService) { _appService = appService; }
    }
}