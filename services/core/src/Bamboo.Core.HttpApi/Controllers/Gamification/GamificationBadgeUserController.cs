using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    [Route("api/v1/human-resources/GamificationBadgeUser")]
    public partial class GamificationBadgeUserController : AbpControllerBase
    {
        private readonly IGamificationBadgeUserAppService _appService;
        public GamificationBadgeUserController(IGamificationBadgeUserAppService appService) { _appService = appService; }
    }
}