using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchOrder")]
    public partial class LunchOrderController : AbpControllerBase
    {
        private readonly ILunchOrderAppService _appService;
        public LunchOrderController(ILunchOrderAppService appService) { _appService = appService; }
    }
}