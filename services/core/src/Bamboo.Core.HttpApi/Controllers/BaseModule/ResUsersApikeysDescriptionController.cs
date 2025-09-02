using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResUsersApikeysDescription")]
    public partial class ResUsersApikeysDescriptionController : AbpControllerBase
    {
        private readonly IResUsersApikeysDescriptionAppService _appService;
        public ResUsersApikeysDescriptionController(IResUsersApikeysDescriptionAppService appService) { _appService = appService; }
    }
}