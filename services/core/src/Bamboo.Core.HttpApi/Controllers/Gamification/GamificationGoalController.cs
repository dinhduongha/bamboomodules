using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationGoal")]
    public partial class GamificationGoalController : AbpControllerBase
    {
        private readonly IGamificationGoalAppService _appService;
        public GamificationGoalController(IGamificationGoalAppService appService) { _appService = appService; }
    }
}