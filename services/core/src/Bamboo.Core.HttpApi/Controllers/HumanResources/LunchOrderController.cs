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
    [Route("api/v1/human-resources/LunchOrder")]
    public partial class LunchOrderController : AbpController
    {
        private readonly ILunchOrderAppService _appService;
        public LunchOrderController(ILunchOrderAppService appService) { _appService = appService; }
    }
}