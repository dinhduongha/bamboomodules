using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResUsersIdentitycheck")]
    public partial class ResUsersIdentitycheckController : AbpController
    {
        private readonly IResUsersIdentitycheckAppService _appService;
        public ResUsersIdentitycheckController(IResUsersIdentitycheckAppService appService) { _appService = appService; }
    }
}