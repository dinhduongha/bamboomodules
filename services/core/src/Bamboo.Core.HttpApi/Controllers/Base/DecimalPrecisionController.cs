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
    // Category: Hidden, Module: base
    [Authorize]
    [Route("api/v1/base/DecimalPrecision")]
    public partial class DecimalPrecisionController : AbpController
    {
        private readonly IDecimalPrecisionAppService _appService;
        public DecimalPrecisionController(IDecimalPrecisionAppService appService) { _appService = appService; }
    }
}