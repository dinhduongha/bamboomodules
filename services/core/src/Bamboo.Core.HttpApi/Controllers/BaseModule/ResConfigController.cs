using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResConfig")]
    public partial class ResConfigController : AbpControllerBase
    {
        private readonly IResConfigAppService _appService;
        public ResConfigController(IResConfigAppService appService) { _appService = appService; }
    }
}