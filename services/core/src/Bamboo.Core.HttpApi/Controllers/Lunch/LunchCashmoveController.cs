using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchCashmove")]
    public partial class LunchCashmoveController : AbpControllerBase
    {
        private readonly ILunchCashmoveAppService _appService;
        public LunchCashmoveController(ILunchCashmoveAppService appService) { _appService = appService; }
    }
}