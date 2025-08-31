using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchOrder")]
    public partial class LunchOrderController : AbpControllerBase
    {
        private readonly ILunchOrderAppService _appService;
        public LunchOrderController(ILunchOrderAppService appService) { _appService = appService; }
    }
}