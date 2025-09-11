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
    [Route("api/v1/base/ResCurrencyRate")]
    public partial class ResCurrencyRateController : AbpController
    {
        private readonly IResCurrencyRateAppService _appService;
        public ResCurrencyRateController(IResCurrencyRateAppService appService) { _appService = appService; }
    }
}