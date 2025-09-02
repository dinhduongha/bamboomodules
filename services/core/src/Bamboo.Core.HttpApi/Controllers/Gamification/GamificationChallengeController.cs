using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationChallenge")]
    public partial class GamificationChallengeController : AbpControllerBase
    {
        private readonly IGamificationChallengeAppService _appService;
        public GamificationChallengeController(IGamificationChallengeAppService appService) { _appService = appService; }
    }
}