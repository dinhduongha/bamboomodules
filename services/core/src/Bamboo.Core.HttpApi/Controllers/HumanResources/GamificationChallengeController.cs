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
    [Route("api/v1/human-resources/GamificationChallenge")]
    public partial class GamificationChallengeController : AbpController
    {
        private readonly IGamificationChallengeAppService _appService;
        public GamificationChallengeController(IGamificationChallengeAppService appService) { _appService = appService; }
    }
}