using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyCard")]
    public partial class LoyaltyCardController : AbpControllerBase
    {
        private readonly ILoyaltyCardAppService _appService;
        public LoyaltyCardController(ILoyaltyCardAppService appService) { _appService = appService; }
    }
}