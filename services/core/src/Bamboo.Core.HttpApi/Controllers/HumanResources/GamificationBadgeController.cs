using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationBadge")]
    public partial class GamificationBadgeController : AbpController
    {
        private readonly IGamificationBadgeAppService _appService;
        public GamificationBadgeController(IGamificationBadgeAppService appService) { _appService = appService; }
    }
}