using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationChallenge")]
    public partial class GamificationChallengeController : AbpControllerBase
    {
        private readonly IGamificationChallengeAppService _appService;
        public GamificationChallengeController(IGamificationChallengeAppService appService) { _appService = appService; }
    }
}