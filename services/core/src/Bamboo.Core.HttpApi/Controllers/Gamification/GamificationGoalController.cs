using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationGoal")]
    public partial class GamificationGoalController : AbpControllerBase
    {
        private readonly IGamificationGoalAppService _appService;
        public GamificationGoalController(IGamificationGoalAppService appService) { _appService = appService; }
    }
}