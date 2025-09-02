using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationBadgeUser")]
    public partial class GamificationBadgeUserController : AbpControllerBase
    {
        private readonly IGamificationBadgeUserAppService _appService;
        public GamificationBadgeUserController(IGamificationBadgeUserAppService appService) { _appService = appService; }
    }
}