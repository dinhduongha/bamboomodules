using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchCashmove")]
    public partial class LunchCashmoveController : AbpController
    {
        private readonly ILunchCashmoveAppService _appService;
        public LunchCashmoveController(ILunchCashmoveAppService appService) { _appService = appService; }
    }
}