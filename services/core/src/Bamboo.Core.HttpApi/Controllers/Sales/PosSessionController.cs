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
    [Route("api/v1/sales/PosSession")]
    public partial class PosSessionController : AbpController
    {
        private readonly IPosSessionAppService _appService;
        public PosSessionController(IPosSessionAppService appService) { _appService = appService; }
    }
}