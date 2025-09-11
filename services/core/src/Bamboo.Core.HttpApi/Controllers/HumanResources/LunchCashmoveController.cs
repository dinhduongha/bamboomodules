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
    // Category: Human Resources/Lunch, Module: lunch
    [Authorize]
    [Route("api/v1/human-resources/LunchCashmove")]
    public partial class LunchCashmoveController : AbpController
    {
        private readonly ILunchCashmoveAppService _appService;
        public LunchCashmoveController(ILunchCashmoveAppService appService) { _appService = appService; }
    }
}