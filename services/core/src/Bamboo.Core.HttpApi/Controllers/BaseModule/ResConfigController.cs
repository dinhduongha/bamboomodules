using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResConfig")]
    public partial class ResConfigController : AbpControllerBase
    {
        private readonly IResConfigAppService _appService;
        public ResConfigController(IResConfigAppService appService) { _appService = appService; }
    }
}