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
    // Category: Sales/Point of Sale, Module: point_of_sale
    [Authorize]
    [Route("api/v1/sales/PosOrder")]
    public partial class PosOrderController : AbpController
    {
        private readonly IPosOrderAppService _appService;
        public PosOrderController(IPosOrderAppService appService) { _appService = appService; }
    }
}