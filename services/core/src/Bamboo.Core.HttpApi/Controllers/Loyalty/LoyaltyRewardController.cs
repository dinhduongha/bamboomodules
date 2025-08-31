using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyReward")]
    public partial class LoyaltyRewardController : AbpControllerBase
    {
        private readonly ILoyaltyRewardAppService _appService;
        public LoyaltyRewardController(ILoyaltyRewardAppService appService) { _appService = appService; }
    }
}