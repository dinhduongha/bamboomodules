using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchProduct")]
    public partial class LunchProductController : AbpControllerBase
    {
        private readonly ILunchProductAppService _appService;
        public LunchProductController(ILunchProductAppService appService) { _appService = appService; }
    }
}