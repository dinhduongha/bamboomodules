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
    [Route("api/v1/sales/PosPreset")]
    public partial class PosPresetController : AbpController
    {
        private readonly IPosPresetAppService _appService;
        public PosPresetController(IPosPresetAppService appService) { _appService = appService; }
    }
}