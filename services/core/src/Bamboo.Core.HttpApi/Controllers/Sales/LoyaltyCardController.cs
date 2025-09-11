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
    // Category: Sales, Module: loyalty
    [Authorize]
    [Route("api/v1/sales/LoyaltyCard")]
    public partial class LoyaltyCardController : AbpController
    {
        private readonly ILoyaltyCardAppService _appService;
        public LoyaltyCardController(ILoyaltyCardAppService appService) { _appService = appService; }
    }
}