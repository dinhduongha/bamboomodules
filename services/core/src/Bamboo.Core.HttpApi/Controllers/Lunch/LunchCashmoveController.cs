using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchCashmove")]
    public partial class LunchCashmoveController : AbpControllerBase
    {
        private readonly ILunchCashmoveAppService _appService;
        public LunchCashmoveController(ILunchCashmoveAppService appService) { _appService = appService; }
    }
}