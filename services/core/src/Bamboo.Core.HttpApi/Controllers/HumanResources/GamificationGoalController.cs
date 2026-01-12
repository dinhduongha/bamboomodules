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
    // Category: Human Resources, Module: gamification
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/GamificationGoal")]
    public partial class GamificationGoalController : AbpController
    {
        private readonly IGamificationGoalAppService _appService;
        public GamificationGoalController(IGamificationGoalAppService appService) { _appService = appService; }
    }
}