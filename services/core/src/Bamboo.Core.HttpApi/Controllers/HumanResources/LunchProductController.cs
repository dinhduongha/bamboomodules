using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Lunch, Module: lunch
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/LunchProduct")]
    public partial class LunchProductController : AbpController
    {
        private readonly ILunchProductAppService _appService;
        public LunchProductController(ILunchProductAppService appService) { _appService = appService; }
    }
}