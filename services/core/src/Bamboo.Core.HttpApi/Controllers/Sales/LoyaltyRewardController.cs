using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/sales/LoyaltyReward")]
    public partial class LoyaltyRewardController : AbpController
    {
        protected readonly ILoyaltyRewardAppService _appService;
        public LoyaltyRewardController(ILoyaltyRewardAppService appService) { _appService = appService; }
        
        
    }
    
}