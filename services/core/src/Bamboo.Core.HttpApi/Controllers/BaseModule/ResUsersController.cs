using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResUsers")]
    public partial class ResUsersController : AbpControllerBase
    {
        private readonly IResUsersAppService _appService;
        public ResUsersController(IResUsersAppService appService) { _appService = appService; }
    }
}