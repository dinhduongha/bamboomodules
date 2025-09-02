using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyReward")]
    public partial class LoyaltyRewardController : AbpControllerBase
    {
        private readonly ILoyaltyRewardAppService _appService;
        public LoyaltyRewardController(ILoyaltyRewardAppService appService) { _appService = appService; }
    }
}