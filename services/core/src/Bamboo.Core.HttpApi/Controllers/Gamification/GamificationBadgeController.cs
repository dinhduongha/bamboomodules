using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationBadge")]
    public partial class GamificationBadgeController : AbpControllerBase
    {
        private readonly IGamificationBadgeAppService _appService;
        public GamificationBadgeController(IGamificationBadgeAppService appService) { _appService = appService; }
    }
}