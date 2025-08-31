using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResUsersIdentitycheck")]
    public partial class ResUsersIdentitycheckController : AbpControllerBase
    {
        private readonly IResUsersIdentitycheckAppService _appService;
        public ResUsersIdentitycheckController(IResUsersIdentitycheckAppService appService) { _appService = appService; }
    }
}