using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationBadge")]
    public partial class GamificationBadgeController : AbpControllerBase
    {
        private readonly IGamificationBadgeAppService _appService;
        public GamificationBadgeController(IGamificationBadgeAppService appService) { _appService = appService; }
    }
}