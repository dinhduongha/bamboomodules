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
    // Category: Sales, Module: loyalty
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/LoyaltyCard")]
    public partial class LoyaltyCardController : AbpController
    {
        private readonly ILoyaltyCardAppService _appService;
        public LoyaltyCardController(ILoyaltyCardAppService appService) { _appService = appService; }
    }
}