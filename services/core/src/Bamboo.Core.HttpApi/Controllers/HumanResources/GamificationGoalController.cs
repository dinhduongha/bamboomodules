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
    // Category: Human Resources, Module: gamification
    [Authorize]
    [Route("api/v1/human-resources/GamificationGoal")]
    public partial class GamificationGoalController : AbpController
    {
        private readonly IGamificationGoalAppService _appService;
        public GamificationGoalController(IGamificationGoalAppService appService) { _appService = appService; }
    }
}