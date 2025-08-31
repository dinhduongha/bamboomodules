using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchProduct")]
    public partial class LunchProductController : AbpControllerBase
    {
        private readonly ILunchProductAppService _appService;
        public LunchProductController(ILunchProductAppService appService) { _appService = appService; }
    }
}